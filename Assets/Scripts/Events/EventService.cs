namespace ChestSystem
{
    public class EventService
    {
        private static EventService instance;
        public static EventService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventService();
                }
                return instance;
            }

        }

        public EventController<int> OnGemsChangedEvent { get; private set; }
        public EventController<int> OnCoinsChangedEvent { get; private set; }
        public EventController<ChestController> OnUnlockChestPressedEvent { get; private set; }

        public EventController OnAllSlotsAreFullEvent { get; private set; }
        public EventController OnNotEnoughResoursesEvent { get; private set; }
        public EventController OnQueueIsFullEvent { get; private set; }

        public EventController<int, ChestController> OnChestSelectedEvent { get; private set; }
        public EventController<int, ChestController> OnUnlockImmidiatelyPressedEvent { get; private set; }

        public EventService()
        {
            OnGemsChangedEvent = new EventController<int>();
            OnCoinsChangedEvent = new EventController<int>();
            OnUnlockChestPressedEvent = new EventController<ChestController>();

            OnAllSlotsAreFullEvent = new EventController();
            OnNotEnoughResoursesEvent = new EventController();
            OnQueueIsFullEvent = new EventController();

            OnChestSelectedEvent = new EventController<int, ChestController>();
            OnUnlockImmidiatelyPressedEvent = new EventController<int, ChestController>();
        }
    }
}
