# ProjectForReview

This is project for review, painting figures on console
- Main fie that runs project you can find by path : Project/Program.cs
- Code with some common(general) part in program you can find by path : Project.Common.Core/
- Code with all classes and interfaces of current project you can find by path : Project.Task/


Changes log:
- The main idea of task is create program to manage state of objects(rectangles and circles), management realized the following way (user pushes buttons in console and object changes own state in appropriate way)
- Created class Rectangle, it contains the following methods (Draw - program draws rectangle in console, Resize - changes size of rectangle, BuildTheSmallest - craeates new rectangle which can contains other two rectangles, RectangleIntersection - create new rectangle as a result of intersection two other rectnagles).
- Created class Circle, it too contains method Draw which draws circle in console, and method Resize that changes radius of circle
- Created class UIPart (this class responses for user interface part, it highlights the place, where program informs user that something happend, also it shows the stats of current object and some exeptions)
- Created class CoordinatesSystem (responses for drawing system of coordinate on the screen)
- Created class ObjectController (responses for management of certain object, it can run methods form other classes that help to manage of object)
- Also craeted interfaces (IDrawable, IChangeable, ICircle and IRectangle, the last two is for overriding Resize function, they inherit from interface IChangeable common part, also IDrawable interface to union objects that can be drawed )
- System of printing in task : program set cursor of console in certain position and draws there symbol, it allows to increase time of printing, because it doesn't make full screen parsing
- All classes and intefaces are placed in appropriate directories
- Code was written by SA rules and code convention standarts

