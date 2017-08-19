# Perceptron
### Console Application
#### By Adrian Agnic (8-18-2017)

## Description
  Represents a single neuron of a neural network. This "Perceptron" receives n number of inputs, 
  and weights those inputs with a random value. After calculating the sum of inputs/weights, converts output to either 1 or -1 (considered a guess).
  Perceptron will modify its weights to slowly achieve values closer to the target(default set to -1) if guess was incorrect.
  
## Formulas
  Activation Function(Feed Forward) 
  * Sign(n) { if ( n >= 0 ) { return 1 } else { return -1 }
  
  Error-Correction(Training)
  * error = answer - guess
  * deltaWeight = error * input * learningRate(default 0.1)
  
## Specs
  * User specifies number of connections(weights) (ex. 20, lowest can be 2)
  * User specifies number of source code elements (ex. 100)
  * User specifies learning rate (ex. 0.1)
  * Perceptron trains itself until target is reached
  
## Pre-Reqs
  * Download Visual Studio 2017
  
## Installation
  * Clone project
  * Open project folder in Visual Studio
  * Run Application:
    * CTRL-F5
    * Or press green play button in VS17
  
## Technologies
  * C#
  * Visual Studio 2017


  
  

