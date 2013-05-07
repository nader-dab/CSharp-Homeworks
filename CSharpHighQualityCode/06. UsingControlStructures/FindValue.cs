bool foundValue = false;

for (int index = 0; index < 100; index++) 
{
	Console.WriteLine(array[i]);
	
	if (index % 10 == 0)
	{
		if (array[i] == expectedValue ) 
		{
			foundValue = true;
			break;
		}
	}
}
// More code here
if (foundValue)
{
    Console.WriteLine("Value Found");
}
