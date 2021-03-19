module Olo.MvuMenu.Update

open Olo.MvuMenu.Model

let update (msg: Msg) (prevState: State): State =

    match msg with

    | AddItem itemId ->
        let newBasket = 
            prevState.Menu.Items
            |> Seq.find (fun mi -> mi.Id = itemId)
            |> Basket.add prevState.Basket
        let nextState = { prevState with Basket = newBasket }
        nextState
