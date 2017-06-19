Feature: Checkout
	Feature to represent a checkout scanner and the ability to calculate the total price of all the items.

Background:
	Given I have a system containing products
	| sku | unitprice | description | specialoffer | quantity | discount |
	| A   | 50.00     | Pineapple   | true         | 3        | 20.00    |
	| B   | 30.00     | Mango       | true         | 2        | 15.00    |
	| C   | 20.00     | Kiwi        | false        | 0        | 0        |
	| D   | 15.00     | Melon       | false        | 0        | 0        |
	| E   | 9.99      | Banana      | true         | 3        | 9.99     |
	And the charge for carrier bags is 0.00

Scenario Outline: Calculate the total price of scanned items
	Given I have a checkout system
	And I scan <quantity> <item> using the checkout
	When I calculate the total price
	Then the subtotal should be <subtotal>
	And the price should be <totalprice>
	And the total discount applied is <totaldiscount>

	Examples:
	| item | quantity | subtotal | totalprice | totaldiscount |
	| A    | 1        | 50.00    | 50.00      | 0             |
	| A    | 2        | 100.00   | 100.00     | 0             |
	| A    | 3        | 150.00   | 130.00     | 20.00         |
	| E    | 3        | 29.97    | 19.98      | 9.99          |