### Project structure

1. SimpleValidation - unit tests that have been created by me. (Tomas Kondrotas)
2. Unit test implementation - implementation of validators given other students unit tests
2.1. UnitTests - unit tests given by my classmate.
2.2. Additional unit tests - unit tests that were added by me.
2.3. Validators - implementation of validators.
 
### Some additional notes

Some unit tests that were given by my classmate were incorrect, for instance the phone numbers is valid, bet the unit test asserts that it will be invalid. For those unit tests I commented them out and added my own. A pull request will be created to my classmates repository with the changes. 

Also to each unit test I added SetUp method (to configure validators configurations), because my implementation requires the setup to be done before usage of the validators. I didn't change the logic of the unit tests. 
