# F# MVU Menu

This is a small Fable app project
to accompany a tech talk on
"F#, Immutability, and the MVU Pattern."

## Workshop Instructions

The step-by-step instructions are [here](instructions.md).

## Requirements

* [Docker Desktop](https://www.docker.com/products/docker-desktop)
* [Visual Studio Code](https://code.visualstudio.com/Download)
* [Remote-Containers](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers) extension for Visual Studio Code

## Project branches

There are two branches:

* `main` - the starter code for the workshop.
* `solution` - the resulting code after completing the workshop.

## Project tools

### npm

JS dependencies are declared in `package.json`, while `package-lock.json` is a lock file automatically generated.

### Webpack

[Webpack](https://webpack.js.org) is a JS bundler with extensions, like a static dev server that enables hot reloading on code changes. Fable interacts with Webpack through the `fable-loader`. Configuration for Webpack is defined in the `webpack.config.js` file. Note this sample only includes basic Webpack configuration for development mode, if you want to see a more comprehensive configuration check the [Fable webpack-config-template](https://github.com/fable-compiler/webpack-config-template/blob/master/webpack.config.js).

### F# Language

All the code in this workshop is written with the general-purpose, functional-first [F# programming language](https://fsharp.org/). The `src` folder contains the F# code.

### Web assets

The `index.html` file and other assets like an icon can be found in the `public` folder.

## For more information

* [Fable.io](https://fable.io)
* [The Elmish Book](https://zaid-ajaj.github.io/the-elmish-book/#/)

## TODO

1. Fix the package.log file issue.
1. Create presentation slides.
1. Practice on someone(s)
