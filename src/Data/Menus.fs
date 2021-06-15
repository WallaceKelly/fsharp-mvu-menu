module Olo.MvuMenu.Menu

type MenuItem = {
    Id: int
    Name: string
    Description: string
    Price: decimal
}

type Menu = {
    Brand: string
    Tagline: string
    Items: MenuItem list
}

let sample = {
    Menu.Brand = "Foosburgers"
    Tagline = "Good food. Great fun."
    Items = [
        { MenuItem.Id = 1
          Name = "Foosburger"
          Description = "Your backyard hamburger, as good as it gets." 
          Price = 8.99M }
        { MenuItem.Id = 2
          Name = "Foosburger with Cheese"
          Description = "Your backyard hamburger, but better." 
          Price = 11.99M }
        { MenuItem.Id = 3
          Name = "Fries"
          Description = "Hand-cut, fried in peanut oil." 
          Price = 4.99M }
        { MenuItem.Id = 4
          Name = "Cajun Fries"
          Description = "Hand-cut, fried in peanut oil, sprinkled with Louisiana seasoning."
          Price = 5.99M }
        { MenuItem.Id = 5
          Name = "Bottled Drink"
          Description = "Drink in, or take it to go."
          Price = 2.99M }
        { MenuItem.Id = 6
          Name = "Milkshake"
          Description = "Yum. Just, yum."
          Price = 5.99M }
    ]
  }