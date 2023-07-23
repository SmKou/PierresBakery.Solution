switch (MainController.Operation)
            {
                case "menu":
                    
                    break;
                case "bread":
                    op = OrderMenuItem.Run(true, order, "bread");
                    break;
                case "pastry":
                case "pastries":
                    op = OrderMenuItem.Run(true, order, "pastry");
                    break;
                case "view":
                case "review":
                    op = ReviewOrder.Run(true, order);
                    break;
                case "y":
                case "yes":
                    op = "menu";
                    break;
                case "cancel":
                case "stop":
                case "n":
                case "no":
                    
                    state = false;
                    break;
                case "submit":
                    
                    state = false;
                    break;
                default:
                    
                    op = Console.ReadLine();
                    break;
            }