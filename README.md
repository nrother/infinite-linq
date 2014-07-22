Infinite LINQ
=============

Handle infinite sequences using LINQ!

When you're using C#, you probably love LINQ. Unfortunally, LINQ seems
to be limited to finite sequences. While this is not a problem most of
the time (you're only have finite problems, right?), using _infinite_
sequences can be fun sometimes.

This is just some testing I've done lately. Feel free to play arround with
it.

Obviously, operations like `Count()` won't work on infinite sequences.

The idea came from some literature about Haskell. I was amazed how easy it
is to calculate the first _n_ primes in Haskell, using some kind of _implicit_
Sieve of Eratosthenes (http://en.wikipedia.org/wiki/Sieve_of_Eratosthenes).
