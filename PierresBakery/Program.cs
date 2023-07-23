global using System;
using PierresBakery.Controllers;
using PierresBakery.Models;
using PierresBakery.Views;

namespace PierresBakery;

public class PierresBakery
{
    public static void Main()
    {
        MainController.Operation = "intro";
        MainController.Receipt = new Order();
        
        while (MainController.State)
        {
            
        }
        
    }
}
