/*

//////// Описание ////////
1) Инкапсуляция - в реализации объединены данные и методы, работающие с этими данными, 
также скрыты детали реализации с помощью модификаторов доступа.
2) Полиморфизм - в реализации классы Dad и Mom наследуются от базового абстрактного класса 
Parent, в котором нет реализации метода мытья рамы. Подразумевается, что мама и папа могут мыть окна по разному.
3) Наследование - в реализации Dad и Mom наследуются от базового абстрактного класса Parent, 
так как мама и папа должны иметь информацию о вымытых рамах и методы, реализующие мытье рамы, которые есть в Parent. 
Parent наследуется от базового абстрактного класса Person, так как все родители как минимум имеют имена, которые есть в Person.
4) Абстракция - в реализации есть 2 абстрактных класса (Person и Parent) имеющие минимальный набор свойств, 
описывающих человека и родителя

*/
    
    abstract class Person
    {
        protected Person(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    abstract class Parent : Person
    {
        protected Parent(string name) : base(name)
        {
            WashedFrames = new List<Frame>();
        }
        public List<Frame> WashedFrames { get; }

        public abstract bool TryWashFrame(Frame frameToWash);
    }

    class Mom : Parent
    {
        public Mom(string name) : base(name)
        {

        }

        public override bool TryWashFrame(Frame frameToWash)
        {
            if (!frameToWash.TryWash(this)) return false;

            WashedFrames.Add(frameToWash);
            return true;
        }
    }

    class Dad : Parent
    {
        public Dad(string name) : base(name)
        {

        }

        public override bool TryWashFrame(Frame frameToWash)
        {
            if (!frameToWash.TryWash(this)) return false;

            WashedFrames.Add(frameToWash);
            return true;
        }
    }

    class Frame
    {
        public Frame(uint id)
        {
            Id = id;
        }

        public bool IsWashed { get; private set; }
        public Person WhoWashed { get; private set; }
        public uint Id { get; }

        public bool TryWash(Parent parent)
        {
            if (IsWashed)
            {
                return false;
            }

            WhoWashed = parent;
            IsWashed = true;
            return true;
        }
    }