# InventoryManagement
ASP.NET project built to fulfill the requirements outlined below:

Stock Management Solution
1. Overview
A Dentist needs to be able to keep track of stock they sell at reception.
As part of your solution:
• List any assumptions that you have made in order to solve this problem.
• Provide a test harness to validate your solution.
2. Stock management
Please create a simple C# Windows desktop application which can keep track of all the stock within a
clinic.
3. Add/Edit Stock Details
Please provide one or more dialogs which will allow the user to manage their stock.
The user should be able to search for a stock item using either the description or Product ID.
Once the stock item is loaded, they should only be allowed to change the amount of stock they have
on hand, the safe stock amount or the price of the stock.
When adding a new stock item, we need to make sure that Product ID is not already in use.
All fields are mandatory when adding a stock item.
4. Sale of Stock
A user should only be able to sell the stock they have on hand.
This should be done via a different screen to where they add or edit the stock, however they should
still be able to search for the stock using either the description or Product ID in this screen as well.
At the point of sale, the user should be allowed to discount the stock price by 5%, 10% or 15%.
Note: You do not have to record who you are selling the stock to.
5. Reordering stock
When a stock item drops below the ‘safe stock amount’ for that stock item, the system should warn
the user of this and should automatically create a new stock order, to order more stock.
The system should always order ‘n’ units up to a maximum of $100 for that stock item. However if
the stock item is worth more than $100, it should only ever order one item.
For example if the unit price was $5, you would order 20 units, if the price was $20, you would order
5 units.
This stock order should be created in the same folder as the software is running in. This file should
be a CSV file and should contain Product ID, Description and Number of units to order.
If the file already exists, the stock order should be appended onto the end of the file.
6. Stock Report
The software needs to display a simple report with the following information for each stock item:
• Product Id
• Description
• Stock on hand
• Number of units sold
• Total dollar amount from sold units
