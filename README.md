# Pierres Bakery

By: Stella Marie

CLI app using C# to make an order.

## **Technologies Used**

- C# .Net 6.0

## **Description**

Pierres Bakery is a CLI app that gathers information from a user to create an order that they can view and edit. The app consists of switch statements acting as controllers. Each controller is responsible for the view for one state. The states are managed by while loops, repeatedly processing a user's input to initiate the main functionality. There are three views: main menu, create order, and review order. Throughout the app, a user can enter the commands--stop, cancel, or menu--to end a state at any time. The states take into account invalid user input and respond accordingly with some degree of flexibility.

## **Complete Setup**

Requires C# compiler.

### **Local Setup**

- Navigate to main page of repo
- Clone or Fork project

```bash
git clone .../.git
git pull origin main
```

- Download required frameworks
- Compile the project
  - Running the project will build it as well

```bash
dotnet restore
dotnet run --project PierresBakery
```

### **Launch App**

To launch the app, presuming you have compiled it, you can either use the terminal in your development environment or the desktop's native terminal (powershell in Windows). Navigate to the project. You have two options:

**Use full path**

```bash
./PierresBakery/bin/Debug/net6.0/PierresBakery.exe
```

**Navigate to local**

```bash
cd PierresBakery/bin/Debug/net6.0/
./PierresBakery.exe
```

## **Known Bugs**

Please report any issues in using the app. For any issues compiling, refer online. 

## **License**

[MIT](https://choosealicense.com/licenses/mit/)

Copyright (c) 2023 Sm Kou
