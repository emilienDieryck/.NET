using LINQDataContext;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// Exercice 1
DataContext dc = new DataContext();


Student? jdepp = (from student in dc.Students
                  where student.Login == "jdepp"
                  select student).SingleOrDefault();

if (jdepp != null)
{
    Console.WriteLine(jdepp.Last_Name + jdepp.First_Name);
}

// Exercice 2.2
// Ecrire une requête pour présenter,
// pour chaque étudiant,
// son nom complet (nom et prénom séparés par un espace),
// son id et sa date de naissance.
// L ’objectif pour cet exercice est de réaliser un maximum dans le query et non dans l’affichage.

var QueryResult = from student in dc.Students
                   select new
                   {
                       Nom = student.First_Name,
                       Prenom = student.Last_Name,
                       Id = student.Student_ID,
                       Date = student.BirthDate
                   };

foreach (var student in QueryResult)
{
    Console.WriteLine(" {0} {1} {2} {3} ", student.Nom, student.Prenom, student.Id, student.Date );
}


// Exercice 3.1 
// Pour chaque étudiant né avant 1955,
// donner le nom, le résultat annuel et le statut.
// Le statut prend la valeur « OK »
// si l’étudiant a obtenu au moins 12 comme résultat annuel
// et « KO » dans le cas contraire.
var QueryResult2 = from student in dc.Students
                   where student.BirthDate.Year < 1955
                   select new
                   {
                       Nom = student.Last_Name,
                       Result = student.Year_Result,
                       Statut = student.Year_Result >=12 ? "OK" : "KO"
                   };

foreach (var student in QueryResult2)
{
    Console.WriteLine(" {0} {1} {2} ", student.Nom, student.Result, student.Statut);
}

// Exercice 3.4
// Ecrire une requête pour présenter
// le nom et le résultat annuel
// classé par résultats annuels décroissants
// de tous les étudiants qui ont obtenu un résultat inférieur ou égal à 3.

var QueryResult3 = from student in dc.Students
                   where student.Year_Result <= 3
                   orderby student.Year_Result descending
                   select new
                   {
                       Nom = student.Last_Name,
                       Result = student.Year_Result,
                   };

foreach (var student in QueryResult3)
{
    Console.WriteLine(" {0} {1} ", student.Nom, student.Result);
}

// Exercice 3.5
// Ecrire une requête pour présenter
// le nom complet (nom et prénom séparés par un espace)
// et le résultat annuel
// classé par ordre croissant
// sur le nom des étudiants appartenant à la section 1110.  

var QueryResult4 = from student in dc.Students
                   where student.Section_ID == 1110
                   orderby student.Last_Name ascending
                   select new
                   {
                       Nom = student.Last_Name,
                       Prenom = student.First_Name,
                       Result = student.Year_Result,
                   };

foreach (var student in QueryResult4)
{
    Console.WriteLine(" {0} {1} {2} ", student.Nom, student.Prenom, student.Result);
}

// Exercice 4.1
// Donner le résultat annuel moyen pour l’ensemble des étudiants.

double moyenne = dc.Students.Average(c => c.Year_Result);

Console.WriteLine(" {0} ", moyenne);
                