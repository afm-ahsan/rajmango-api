namespace RajMango.Application.DTOs
{
    public class FeatureModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool HasAccess { get; set; }
        public List<ActionModel> ActionModels { get; set; }
    }
}
