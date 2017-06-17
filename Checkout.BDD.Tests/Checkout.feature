Feature: Checkout
	Feature to respresent a checkout scanner and the ability to calculate the total price of all the items.

@Ignore
Scenario: Calculate the total price of a scanned item
	Given I have a checkout system
	And I scan an item using the checkout
	When I calculate the total price
	Then the totalprice should be correct
	| item | unitprice | totalprice |
	| A    | 9.99      | 9.99       |