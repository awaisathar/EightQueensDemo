EightQueensDemo
===============

Demo for Solving the 8 Queens Problemusing BFS and DFS

Some eons ago, I taught a course in Artificial Intelligence. For some parts of the course, I  implemented demos along with the course material. Looking from the students’ point of view, such tools not only decrease the learning time while in the class room, but also give enough material to play around at home in case you want to repeat what was taught. While preparing the first few lectures, I realized I needed a simulation of the 8 Queens Problem using Breadth First Search and Depth First Search. While there are many solutions on the Internet, I couldn’t find any program which lets me step through the algorithm. Besides, it had been a long time since  I did any programming in Windows.Forms so my code deprived fingers needed a sink.

![8 Queens Demo](http://chaoticity.com/images/8queens_thumb1.png)

So here’s my version of the 8 queens problem solver in C#. Each board state is represented by a string. The string represent the columns starting from the left most column and the number in that position tells the row in which a queen is present.  The screenshot above thus represents the state 03142. The state 0314 would represent an empty column 4. You can download the compiled binary from [my original blog post](http://chaoticity.com/8queens/). Keep in mind that the code hacky and badly written and should not be used in assignments. If you want a ready-made assignment, search elsewhere (or still better, drop out and do something you really love => ). Comments/Suggestions/Bug Reports are welcome.
