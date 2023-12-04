using System;

public class Statement
{
    public long Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Patronymic { get; set; }
    public DateTime BirthDate { get ; set; }
    public string Features { get; set; }

    public string ApplicantLastName { get; set; }
    public string ApplicantFirstName { get; set; }
    public string ApplicantPatronymic { get; set; }

    public DateTime DateTimeOfStatement { get; set; }

    public double Longitude { get; set; }
    public double Latitude { get; set; }
}
