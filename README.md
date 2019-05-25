# WaveDotNet
A simple sound synthesis software.

![Example](https://repository-images.githubusercontent.com/174710616/65588680-7b3e-11e9-8584-8ac66c7634d9)

A video presenting the application (in which I also talk a little bit about the source code) can be found here: https://www.youtube.com/watch?v=VlJRcENgmww

Pretty soon I will try to write few more words describing this projects on my blog (and maybe create a YouTube video demonstrating it).

The WaveDotNet is an application I've created just as my WPF playground. If you are a professional musician then you are probably in a wrong place. You won’t be able to create the next masterpiece using it, but still it was fun to mess around with it as my pet project.

For sound generation, on the lowest level (writing to the audio buffer), it uses NAudio library created by Mark Heath. In the middle resides my own library that defines a set of common wave transformations and gives its user a way to organize them in a stateless, tree-like structure. And on top of that there is the WPF frontend filled with some fancy converters and slick view models. 

The editor itself acts as a canvas on which the user can place new nodes, modify them, manage them, and what’s most important, connect them. It also provides some basic preview of the shape of the wave produced in the given configuration. And of course once the structure is valid, you can play it – well, that’s the point after all.
