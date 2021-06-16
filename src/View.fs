module Olo.MvuMenu.View

open Feliz
open Feliz.Bulma
open Olo.MvuMenu.Model
open Olo.MvuMenu.Menu
open Olo.MvuMenu.Basket

let formatPrice (p: decimal) = sprintf "$%.2f" p

let renderBanner (brand: string) (tagline: string) =
    Bulma.hero [
      color.isPrimary
      prop.children [
        Bulma.heroBody [
          Bulma.title brand
          Bulma.subtitle tagline
        ]
      ]
    ]

let renderMenuItem (dispatch: Msg -> unit) (item: MenuItem) =
  Html.li [
    Bulma.box [
      Bulma.columns [
        columns.isVCentered
        prop.children [
          Bulma.column [
            column.isNarrow
            button.isMedium
            color.isPrimary
            prop.className "button fa fa-plus"
            prop.onClick (fun _ -> dispatch (AddItem item.Id))
          ]
          Bulma.column [
            Html.paragraph [
              text.hasTextWeightBold
              prop.children [ Html.text item.Name ]
            ]
            Html.paragraph [
              prop.children [ Html.text item.Description ]
            ]
          ]
          Bulma.column [
            column.isNarrow
            prop.children [
              Html.text (formatPrice item.Price)
            ]
          ]
        ]
      ]
    ]
  ]

let renderMenuItems (dispatch: Msg -> unit) (menu: Menu) =
  Html.ul [
    for item in menu.Items ->
      renderMenuItem dispatch item
  ]

let renderMenu (dispatch: Msg -> unit) (menu: Menu) =
  Bulma.block [
    Bulma.title "Menu"
    Bulma.subtitle "Choose from our short list of options."
    renderMenuItems dispatch menu
  ]

let renderBasketItem (dispatch: Msg -> unit) (item: BasketItem) =
    let lineItem = $"{item.MenuItem.Name} {formatPrice item.MenuItem.Price}"
    Html.li (
      Bulma.columns [
        columns.isVCentered
        prop.children [
          Bulma.column (Html.text lineItem)
          Bulma.column [
            column.isNarrow
            prop.children [
              Bulma.button.button [
                button.isSmall
                color.isLight
                prop.className "fa fa-minus"
                prop.onClick (fun _ -> dispatch (RemoveItem item.Id))
              ]
            ]
          ]
        ]
      ]
    )

let renderBasketItems (dispatch: Msg -> unit) (basket: Basket) =
    let subtotal = basket.Items |> Seq.sumBy(fun i -> i.MenuItem.Price)
    Bulma.block [
      Bulma.box [
        Html.ul [
          let items = basket.Items
          for item in items do
            yield renderBasketItem dispatch item
        ]
      ]
      Bulma.block [
        text.hasTextRight
        text.hasTextWeightBold
        prop.children [
          Html.text $"Subtotal: {formatPrice subtotal}"
        ]
      ]
    ]

let renderEmptyBasket () =
    Bulma.box [
      Html.i [
        prop.className "far fa-sad-tear"
      ]
      Html.text " Nothin' yet."
    ]

let renderBasket (dispatch: Msg -> unit) (basket: Basket) =
  Bulma.block [
    Bulma.title "Basket"
    Bulma.subtitle "What you have to look forward to!"

    if basket.Items.Length > 0 then
      renderBasketItems dispatch basket
    else
      renderEmptyBasket ()
  ]

let renderFooter () =
  Bulma.heroFoot [
      text.hasTextCentered
      prop.children [
        Html.strong "MVU Menu"
        Html.text ", an ordering application for educational purposes."
      ]
  ]

let renderLayout (menu: unit -> ReactElement) (basket: unit -> ReactElement) =
    Bulma.section [
      Bulma.tile [
        tile.isAncestor
        prop.children [
          Bulma.tile [
            tile.isAncestor
            tile.is8
            prop.children [ menu() ]
          ]
          Bulma.tile [
            tile.isAncestor
            tile.is4
            prop.children [ basket() ]
          ]
        ]
      ]
    ]

let render (state: State) (dispatch: Msg -> unit) =
  Bulma.container [
    renderBanner state.Menu.Brand state.Menu.Tagline
    renderLayout
      (fun () -> renderMenu dispatch state.Menu)
      (fun () -> renderBasket dispatch state.Basket)
    renderFooter()
  ]


