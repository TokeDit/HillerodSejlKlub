using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Library;
using System.Text.Json;



//BoatRepo boats = new BoatRepo();
//MemberRepo memberRepo = new MemberRepo();
//BookingRepo bookingRepo = new BookingRepo();
//BoatRepo boatRepo = new BoatRepo();
//BlogRepo blogRepo = new BlogRepo();
//EventRepo eventRepo = new EventRepo();





//string json = File.ReadAllText("/home/stefan/projects/SchoolShit/HillerodSejlKlub/Data/Member.json");
// Member member1

MainHandler main = new MainHandler();

// JsonNode member1 = JsonObject.Parse(File.ReadAllText("/home/stefan/projects/SchoolShit/HillerodSejlKlub/Data/Member.json"));
// JsonArray jsonValue = member1.AsArray();
// Console.WriteLine(jsonNode.ToString());


// boatRepo.AddBoat(new Boat("Amada", "f", "g", new(2000, 12, 25), 4525412, "2,5l", 25, 1));
// boatRepo.AddBoat(new Boat("Karl", "f", "44",new(2001, 10, 10), 541256, "2,5", 30, 2));
// boatRepo.AddBoat(new Boat("Sandra", "f", "h", new(1990, 5, 24), 521524, "3,5", 30, 3));

// memberRepo.AddMember(new Member("Toke", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
// memberRepo.AddMember(new Member("Lars", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
// memberRepo.AddMember(new Member("Esti", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
// memberRepo.AddMember(new Member("Stefan", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));
// memberRepo.AddMember(new Member("Toke", "Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Member.BoatSize.large, Member.Acceslevel.admin));

// //for testing, should be added runtime.
// eventRepo.AddEvent(new Event("Boat trip", new DateTime(2025, 05, 01, 12, 00, 00), new DateTime(2025, 05, 01, 18, 00, 00), memberRepo.FindMemberByName("Esti")));

// //for testing, should be added runtime.
// blogRepo.AddBlog(new Blog("Boat trip", new DateTime(2025, 05, 06, 12, 00, 00), new DateTime(2025, 05, 06, 18, 00, 00), "Boat trip to check boat functionality.", memberRepo.FindMemberByName("Esti")));


// bookingRepo.AddBooking(new Booking(new(2023, 12, 31, 12, 00, 00), new(2025, 1, 1, 10, 00, 00), memberRepo.FilterMemberById(1), boatRepo.FilterBoatById(1).ElementAt(0), "ingen"));
// bookingRepo.AddBooking(new Booking(new(2024, 12, 25, 10, 00, 00), new(2025, 1, 1, 10, 00, 00), memberRepo.FilterMemberById(2), boatRepo.FilterBoatById(2).ElementAt(0), "ingen"));


// Console.WriteLine(bookingRepo.ReturnListAsString(bookingRepo.FilterBookingByBoatName("Amanda")));

// Console.WriteLine(memberRepo.ReturnListAsString(memberRepo.FilterMemberByName("Toke")));

// try
// {
// 	boats.FilterBoatByName("Claus");
// }
// catch (NoSearhResultException noResult)
// {
//     Console.WriteLine(noResult.Message);
// }

// Console.WriteLine(bookingRepo.FilterBookingById(1).ToString());

// Console.WriteLine(bookingRepo.FilterBookingById(2).ToString());

