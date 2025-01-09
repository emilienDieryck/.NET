using SchoolApp.Repository;
using SchoolApp.Models;
using SchoolApp.Repositories;

SectionRepositoryMem sectionRepositoryMem = new SectionRepositoryMem();
StudentRepositoryMem studentRepositoryMem = new StudentRepositoryMem();

Console.WriteLine("Avant Ajout: " + sectionRepositoryMem.GetAll().Count);

Section sectInfo = new Section { Name = "Informatique" };
Section sectDiet = new Section { Name = "Diététique" };

// Accepter
sectionRepositoryMem.Save(sectInfo, s => s.Name == sectInfo.Name);
sectionRepositoryMem.Save(sectDiet, s => s.Name == sectDiet.Name);

// Refuser
sectionRepositoryMem.Save(sectDiet, s => s.Name == sectDiet.Name);

Console.WriteLine("Apres Ajout: " + sectionRepositoryMem.GetAll().Count);
