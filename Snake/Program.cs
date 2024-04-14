// See https://aka.ms/new-console-template for more information

using Snake;

var snake = new Snake.Snake(10, '\u2588');
var board = new Board(80, 20);
board.InitializeBoardArray(snake);

board.Draw();