module Olo.MvuMenu.Model

open System
open Olo.MvuMenu.Menu
open Olo.MvuMenu.Basket

type State = {
    Menu: Menu
    Basket: Basket
}

type Msg =
    | AddItem of int

let init() = {
    Menu = Menu.sample
    Basket = { Basket.Items = [] }
}

