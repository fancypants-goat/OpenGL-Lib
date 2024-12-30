import tkinter as tk
from tkinter import ttk, filedialog, scrolledtext
from typing import Literal, TypeAlias

import os
import sys
import platform
import threading
import subprocess
import xml.etree.ElementTree as ET
import shutil


############ CONST VARIABLES ############

DARK_GREY = '#333333'
GREY = '#4F4F4F'
WHITE = '#FFFFFF'
BLACK = '#000000'

browse_dir_mode: TypeAlias = Literal['project', 'engine']

############ FUNCTIONS ############

def log_info(message: str) -> None:
    proj_progress_text.configure(state='normal') # enable editing
    proj_progress_text.insert('end', message + '\n') # add message to the info log
    proj_progress_text.see('end') # scroll to the end
    proj_progress_text.configure(state='disabled') # disable editing



def browse_directory(variable: tk.Variable, mode: browse_dir_mode, initialdir:str = '') -> None:
    folder_selected = filedialog.askdirectory(title=f'Select {mode} root', initialdir=initialdir)
    if folder_selected:
        variable.set(folder_selected)



def log_project_info(project_name, project_root, engine_root) -> None:
    log_info(f'--- project info ---')
    log_info(f'project name         {project_name}')
    log_info(f'project root         {project_root}')
    log_info(f'engine root          {engine_root}')
    log_info(f'--------------------')



def validate_project_info(project_name: str, project_root: str, engine_root: str) -> bool:
    # check if the project_name and project_root are both given
    if not project_name or not project_root:
        log_info('Please insert a name and root folder')
        return False
    
    # check if the engine_root is given
    if not engine_root:
        log_info('Please insert an engine root folder')
        return False

    # make sure the engine_root folder exists and contains the game engine
    # check for linux os
    elif platform.system() == 'Linux':
        engine_path: str = os.path.join('Z', engine_root, 'OpenGL-Lib.csproj')
        if not os.path.exists(engine_path):
            log_info ('Engine root either doesn\'t exist or does not contain the engine')
            return False
    
    # check for windows os
    elif platform.system() == 'Windows':
        engine_path: str = os.path.join(engine_root, 'OpenGL-Lib.csproj')
        if not os.path.exists(engine_path):
            log_info ('Engine root either doesn\'t exist or does not contain the engine')
            return False


    # if all inputs and paths are valid
    return True



def get_default_engine_root() -> str:
    if platform.system() == 'Linux':
        return os.path.join('/home', 'michiel', 'Programs', 'C#', 'OpenGL-Lib')
    elif platform.system() == 'Windows':
        return os.path.join('C:/', 'Programs', 'C#', 'OpenGL-Lib')
    else:
        return os.getcwd()



def run_command(command: list[str], log_message_func: any) -> None:
    try:
        # run the command
        process = subprocess.Popen(
            command, stdout=subprocess.PIPE, stderr=subprocess.PIPE, text=True
        )
        # print all the log info in real time
        for line in iter(process.stdout.readline, ''):
            log_message_func(line.strip())  # Log standard output
        for line in iter(process.stderr.readline, ''):
            log_message_func(f'ERROR: {line.strip()}')  # Log standard error
        
        # close the output
        process.stdout.close()
        process.stderr.close()
        # log any error codes
        return_code = process.wait()
        if return_code != 0:
            log_message_func(f'Command failed with return code {return_code}')
    except Exception as e:
        # any error with the command itself or terminal will be handled here 
        log_message_func(f'An unexpected error occurred: {e}')



def create_contents(project_name: str, project_path: str) -> None:
    # create the cs contents
    # Launch.cs:
    launch_cs_content: str = f'''\
using OpenGL;



namespace {project_name};

public class Launch
{{
    public static void Main(string[] args)
    {{
        WindowSettings.SetWindowSize((800, 600));
        WindowSettings.SetWindowTitle("Game Window");
        WindowSettings.SetWindowLocation(0);

        Game program = new();
        program.Run();
    }}
}}
'''
    
    # Program.cs:
    program_cs_content: str = f'''\
using OpenGL;
using OpenTK.Mathematics;



namespace {project_name};

public class Game : Program
{{
    public override void Create()
    {{
        new Camera(new Vector3(0, 0, -10), new Vector3(0), 100, 0, 1000, true);
        new GameObject("OpenGL-Logo", new Vector3(0), new Vector3(20, 20, 0), new Vector3(0), Texture.FromFile(Assets.GetFilePath("OpenGL-Logo.png")));
    }}
}}
'''

    try:
        launch_cs_path: str = os.path.join(project_path, 'Launch.cs')
        program_cs_path: str = os.path.join(project_path, 'Program.cs')
        # create and write the Launch.cs file
        with open(launch_cs_path, 'w') as file:
            file.write(launch_cs_content)
        
        # write the Program.cs file
        with open(program_cs_path, 'w') as file:
            file.write(program_cs_content)
        
        # create the assets folder
        os.mkdir(os.path.join(project_path, 'Assets'))
    except Exception as e:
        log_info(f'An unexpected error occurred: {e}')



def add_content_tag_to_csproj(csproj_path):
    try:
        # Parse the .csproj file
        tree = ET.parse(csproj_path)
        root = tree.getroot()

        # Define the namespace (if required)
        ns = {'msbuild': 'http://schemas.microsoft.com/developer/msbuild/2003'}
        ET.register_namespace('', ns['msbuild'])

        # Find an existing <ItemGroup> or create one
        item_group = None
        for elem in root.findall('ItemGroup', ns):
            item_group = elem
            break

        if not item_group:
            # If no <ItemGroup> exists, create a new one
            item_group = ET.SubElement(root, 'ItemGroup')

        # Add the new <Content> tag
        content_element = ET.SubElement(item_group, 'Content', {'Include': 'Assets/**/*'})
        copy_element = ET.SubElement(content_element, 'CopyToOutputDirectory')
        copy_element.text = 'PreserveNewest'

        # Write changes back to the .csproj file
        tree.write(csproj_path, encoding='utf-8', xml_declaration=True)
        log_info(f'Successfully added <Content> tag to an <ItemGroup> in {csproj_path}.')
    except Exception as e:
        log_info(f'Error: {e}')



def create_project(project_name: str, project_root: str, engine_root: str) -> None:
    try:
        # create the root directory to ensure it exists
        log_info('creating project root')
        os.makedirs(project_root, exist_ok=1)

        # navigate to the project root
        log_info('navigating to project root')
        os.chdir(project_root)


        # run the dotnet command to create a new project
        log_info('creating dotnet project')
        run_command(['dotnet', 'new', 'console', '-n', project_name], log_info)

        # navigate into the project folder
        log_info('navigating to project folder')
        project_folder = os.path.join(project_root, project_name)
        os.chdir(project_folder)

        # get the path to my game engine
        game_engine_path = os.path.join(engine_root, 'OpenGL-Lib.csproj')

        # add the needed packages
        log_info('adding game engine reference to dotnet project')
        run_command(['dotnet', 'add', 'reference', game_engine_path], log_info)

        # create and write the needed cs files
        log_info('creating default project files')
        create_contents(project_name, project_folder)

        # add the Include assets tag to the csproj file
        log_info(f'adding Include tags to {project_name}.csproj')
        add_content_tag_to_csproj(os.path.join(project_folder, f'{project_name}.csproj'))

        # copy logo
        log_info(f'copying assets')
        shutil.copy2(os.path.join(engine_root, "OpenGL-Logo.png"), os.path.join(project_folder, "Assets"))

        # build the project
        log_info('building project')
        run_command(['dotnet', 'build'], log_info)
        
        if (open_proj_in_code_var.get()):
            log_info('opening project in vscode')
            run_command(['code', '.'], log_info)

    except subprocess.CalledProcessError as e:
        log_info(f'An error occurred while running shell commands: {e}')

    except Exception as e:
        log_info(f'An unexpected error occurred: {e}')
    
    finally:
        log_info('finished creating project')



def initialize_project() -> None:
    project_name = proj_name_entry.get()
    project_root = proj_dir_entry.get()
    engine_root = engine_dir_entry.get()

    if not validate_project_info(project_name, project_root, engine_root):
        return

    log_project_info(project_name, project_root, engine_root)

    log_info('starting creation of project')
    threading.Thread(target=create_project, args=(project_name, project_root, engine_root), daemon=True).start()



############ MAIN LOGIC ############

# create a window
window = tk.Tk()
window.title('Project Creator')
window.config(bg=DARK_GREY)


# create the main frames
proj_creation_frame = tk.Frame(window, bg=DARK_GREY)
proj_progress_frame = tk.Frame(window, bg=DARK_GREY)


proj_name_label = ttk.Label(proj_creation_frame, text="Project Name: ", background=DARK_GREY, foreground=WHITE)
proj_name_entry = ttk.Entry(proj_creation_frame, background=DARK_GREY)

# project root
proj_dir_label = ttk.Label(proj_creation_frame, text="Project root: ", background=DARK_GREY, foreground=WHITE)
proj_dir_var = tk.StringVar()
proj_dir_entry = ttk.Entry(proj_creation_frame, textvariable=proj_dir_var)
proj_dir_browse_button = tk.Button(proj_creation_frame, text="browse", height=1, bg=GREY, fg=BLACK, command=lambda: browse_directory(proj_dir_var, 'project', proj_dir_var.get()))

# engine root
engine_dir_label = ttk.Label(proj_creation_frame, text="Engine root: ", background=DARK_GREY, foreground=WHITE)
engine_dir_var = tk.StringVar()
engine_dir_var.set(get_default_engine_root())
engine_dir_entry = ttk.Entry(proj_creation_frame, textvariable=engine_dir_var)
engine_dir_browse_button = tk.Button(proj_creation_frame, text="browse", height=1, bg=GREY, fg=BLACK, command=lambda: browse_directory(engine_dir_var, 'engine', engine_dir_var.get()))

# open project in vscode after creation checkbutton
open_proj_in_code_var = tk.BooleanVar(value=False)
open_proj_in_code = tk.Checkbutton(proj_creation_frame, text="open project in vscode", variable=open_proj_in_code_var, bg=DARK_GREY, highlightbackground=DARK_GREY, highlightcolor=WHITE, activebackground=DARK_GREY, activeforeground=WHITE)

# create project button
proj_create_button = tk.Button(proj_creation_frame, text="Create", width=20, bg=GREY, fg=BLACK, command=initialize_project)

# the project debug info scrolledtext
proj_progress_text = scrolledtext.ScrolledText(proj_progress_frame, wrap="word", height=20, state="disabled", bg=DARK_GREY, fg=WHITE)


# draw all the stuff to the screen
proj_name_label.grid(row=0, column=0, sticky="NEWS", padx=5, pady=10)
proj_name_entry.grid(row=0, column=1, sticky="E", padx=5, pady=10)

proj_dir_label.grid(row=1, column=0, sticky="NEWS", padx=5, pady=10)
proj_dir_entry.grid(row=1, column=1, sticky="E", padx=5, pady=10)
proj_dir_browse_button.grid(row=1, column=3, sticky="NEWS")

engine_dir_label.grid(row=2, column=0, sticky="NEWS", padx=5, pady=10)
engine_dir_entry.grid(row=2, column=1, sticky="E", padx=5, pady=10)
engine_dir_browse_button.grid(row=2, column=3, sticky="NEWS")

open_proj_in_code.grid(row=3, column=0, columnspan=2, sticky="NSW", pady=20)

proj_create_button.grid(row=4, column=0, columnspan=2, sticky="NS", pady=20)

proj_progress_text.pack(fill="both", expand=True)

proj_creation_frame.grid(row=0, column=0)
proj_progress_frame.grid(row=1, column=0)


# run the window
window.mainloop()
