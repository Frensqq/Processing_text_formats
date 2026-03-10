using ConcoleInterface;

ConsoleMethods consoleMethods = new ConsoleMethods();

while (true)
{
    int task = consoleMethods.Menu();

    if (task == 0) break;
    if (task == -1) continue;
}