namespace StudentManagementSystem.Contracts.Request
{
    public class UpdateStudentRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Age { get; set; }
        public string Course { get; set; } = null!;
    }
}
