Feature: Carrier Bag
	Feature to represent how many bags are required for the shopping.

Background:
	Given the cost for each carrier bag is 0.05
	And the bag capacity holds 5 items

Scenario Outline: Calculate how many bags are required for the shopping
	Given I have a carrier bag
	And I have <numberOfItems> in my shopping basket
	Then the total number of bags required is <numberOfBagsRequired>
	And the total charge for bags in <bagCharge>

Examples:
	| numberOfItems | numberOfBagsRequired | bagCharge |
	| 0             | 0                    | 0.00      |
	| 1             | 1                    | 0.05      |
	| 5             | 1                    | 0.05      |
	| 6             | 2                    | 0.10      |
	| 10            | 2                    | 0.10      |
	| 11            | 3                    | 0.15      |
	| 20            | 4                    | 0.20      |