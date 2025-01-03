#version 330 core

in vec2 texCoord;

uniform sampler2D texture0;
uniform vec4 color;
uniform int useTexture;

out vec4 FragColor;

void main()
{
    if (useTexture == 1)
    {
        FragColor = texture(texture0, texCoord) * color;
    }
    else
    {
        FragColor = color;
    }
}
