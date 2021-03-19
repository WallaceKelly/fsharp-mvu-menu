# Workshop Instructions

## Learning Objectives

* Modify F# code to meet new requirements.
* Add a message to an MVU application.

## Workshop Setup

These instructions use a Docker Development Environment to host all the code and the running application.

1. Install and run the following on your machine:

    * [Docker Desktop](https://www.docker.com/products/docker-desktop)
    * [Visual Studio Code](https://code.visualstudio.com/Download)

1. Create a [GitHub account](https://github.com/join) for yourself, if you do not already have one.

1. In Visual Studio Code, install the [Remote-Containers](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers) extension.

    * Press `Ctrl-P` followed by `>`
    * Type `Extensions:`
    * Select `Install Extensions`
    * Search for `Remote-Containers`
    * Click the `install` button.

1. In Visual Studio Code, start the Remote Development Environment:

    * Press `Ctrl-P` followed by `>`
    * Type `Remote-Containers`
    * Select `Clone Repository in Container Volume...`
    * Select `Clone a reposiory from GitHub in a Container Volumne`
    * If requested, authorize VS Code to use your GitHub credentials.
    * Type `ololabs/fsharp-mvu-menu`
    * Select `main`
    * Click on "Starting Dev Container (show log)" in the bottom right corner to monitor startup progress.
    * Wait for the startup to complete. (It may required several minutes the first time.)

1. Confirm successful startup.

    * With a browser, load http://localhost:8080
    * Add an item from the menu to your basket.

## Practice Objectives

Your program manager has asked you to make the following improvements to the restaurant website.

1. Add "Milkshake" to the list of menu items.
1. Hide the subtotal if the basket is empty.
1. Prefix the subtotal with the text "Subtotal: ".
1. Bold the subtotal.
1. Sort the items in the basket.
1. Add a "Remove" button to each basket item.
1. Add the ability to remove items from the basket.

## Workshop Instructions

1. Add "Milkshake" to the list of menu items.

    * In Menu.fs add another F# record instance to the list of sample menu items.
    * Notice that new item appears on the menu in the browser.  

1. Sort the items in the basket.

    * In Basket.fs, find the `add` function.
    * In the `add` function, identify where the `nextBasket` is being created.
    * When the `nextBasket` is created, a new list is created with the new item appended.  
      ```fsharp
      Items = prevBasket.Items
              |> List.append [ newBasketItem ]
      ```
    * Sort the items.  
      ```fsharp
      Items = prevBasket.Items
              |> List.append [ newBasketItem ]
              |> List.sortBy (fun i -> i.MenuItem.Id)
      ```

1. Prefix the subtotal with the text "Subtotal: ".

    * In View.fs, find the `renderBasketItems` (_plural_) function definition.
    * Find the line that displays the subtotal.
    * Update that line to prefix the subtotal amount with the text "Subtotal: ".

1. Bold the subtotal.

    * Continuing in the `renderBasketItems` function, notice that the subtotal is styled to be right-aligned text.
    * Follow that example to set the subtotal text to also be bold.

1. Hide the subtotal if the basket is empty.

    * Continuing in View.fs, find the `renderBasket` function definition.
    * Notice where it calls the `renderBasketItems` function.
    * If the length of the items in the basket is zero, call the `renderEmptyBasket ()` function instead.

1. Add a "Remove" button to each basket item.

    * Continuing in View.fs, find the `renderBasketItem` (_singular_) function.
    * Find the column that displays the `Html.text lineItem`.
    * Below that column, add a new column like this:  

    ```fsharp
        Bulma.column (Html.text lineItem)
        // add this column
        Bulma.column [
            column.isNarrow
            prop.children [
                Bulma.button.button [
                    button.isSmall
                    color.isLight
                    prop.className "fa fa-minus"
                ]
            ]
        ]
    ```

    * Notice that the buttons appear on the UI but are not yet functional.
    * Add an event handler to the "Remove" button, like this:

    ```fsharp
        Bulma.column (Html.text lineItem)

        Bulma.column [
            column.isNarrow
            prop.children [
                Bulma.button.button [
                    button.isSmall
                    color.isLight
                    prop.className "fa fa-minus"
                    // add this event handler
                    prop.onClick (fun _ -> dispatch (RemoveItem item.Id))
                ]
            ]
        ]
    ```

    * Notice that the newly added event handler is dispatching a message `RemoveItem`. When dispatching that message, the Id of the item to remove is included. However, the `RemoveItem` message has not been defined yet. Consequently, the project will not compile.

1. Add the ability to remove items from the basket.

    * In Model.fs, add a new `Msg` to remove an item for a given `Guid`.
    * In Update.fs, notice that there is a warning that the `match msg with` does not handle all the possible cases.
    * Try to write the code to handle the new case of removing an item.
        * First, use `Basket.remove` to create a new basket from the old basket, but with the given item removed.
        * Then, create and return a copy of the previous state, but with the old basket replaced with the new basket.
        * Peek at the solution, if necessary.

## Workshop solution

Look at the commits on the solution branch to see [the suggested solution](https://github.com/ololabs/fsharp-mvu-menu/commits/solution).
