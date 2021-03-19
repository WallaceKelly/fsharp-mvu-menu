module Olo.MvuMenu.Basket

open System
open Olo.MvuMenu.Menu

type BasketItem = {
    Id: Guid
    MenuItem: MenuItem
}

type Basket = {
    Items: BasketItem list
}

let add (prevBasket: Basket) menuItem =
    let newBasketItem = {
        Id = Guid.NewGuid()
        MenuItem = menuItem
    }
    let nextBasket = {
        prevBasket with
            Items = prevBasket.Items
                    |> List.append [ newBasketItem ]
    }
    nextBasket

let remove (prevBasket: Basket) basketItemId =
    let itemToRemove =
        prevBasket.Items
        |> List.where(fun i -> i.Id = basketItemId)
    let nextBasket = {
        prevBasket with
            Items = prevBasket.Items |> List.except(itemToRemove)
    }
    nextBasket