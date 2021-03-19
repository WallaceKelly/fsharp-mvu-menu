module Olo.MvuMenu.App

open Elmish
open Elmish.React

Program.mkSimple Model.init Update.update View.render
|> Program.withReactSynchronous "mvu-menu-app"
|> Program.run