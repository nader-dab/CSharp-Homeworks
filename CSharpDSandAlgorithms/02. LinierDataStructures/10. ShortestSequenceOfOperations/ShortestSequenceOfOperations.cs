namespace _10.ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;

    public class ShortestSequenceOfOperations
    {
        private struct Number
        {
            public int Value { get; set; }
            public int PrevStepIndex { get; set; }
        }

        public static void Main(string[] args)
        {
            Console.Write("please enter N: ");
            int startNumber = int.Parse(Console.ReadLine());

            Console.Write("please enter M: ");
            int endNumber = int.Parse(Console.ReadLine());

            Number startingOperation = new Number()
            {
                Value = startNumber,
                PrevStepIndex = 0,
            };

            Queue<Number> operations = new Queue<Number>();
            operations.Enqueue(startingOperation);

            List<Number> totalOperations = new List<Number>();
            totalOperations.Add(startingOperation);

            int currentNumber = startingOperation.Value;
            int lastStep = startingOperation.PrevStepIndex;

            while (currentNumber != endNumber)
            {
                Number currentOperation = operations.Dequeue();

                totalOperations.Add(currentOperation);

                currentNumber = currentOperation.Value;
                lastStep = currentOperation.PrevStepIndex;

                operations.Enqueue(new Number() { Value = currentNumber + 1, PrevStepIndex = totalOperations.Count - 1 });
                operations.Enqueue(new Number() { Value = currentNumber + 2, PrevStepIndex = totalOperations.Count - 1 });
                operations.Enqueue(new Number() { Value = currentNumber * 2, PrevStepIndex = totalOperations.Count - 1 });
            }

            Stack<int> reconstructedSteps = new Stack<int>();
            reconstructedSteps.Push(currentNumber);

            int stepIndex = lastStep;

            while (stepIndex != 0)
            {
                reconstructedSteps.Push(totalOperations[stepIndex].Value);
                stepIndex = totalOperations[stepIndex].PrevStepIndex;
            }

            Console.WriteLine(string.Join(" -> ", reconstructedSteps));
        }
    }
}
