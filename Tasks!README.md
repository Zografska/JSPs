# JSPs
Dobrodojdovte vo svetot na taskovite :)
Ke napisham nekolku rabotki so treba nekoj od nas da gi sredi :0
Dosega, kreeirani se osnovnite CRUD operacii, za site modeli potrebni za applikacijata e kreiran kontroler

Raboti so preostanuvaat:
[Priority: High]
- Pri create na bus stop da se dodade mehanizam da dodavanje poveke avtobusi koiso se vekje vo databazata (Odi vo busStops, probaj da kreirash postojka, i sporedi so podatoci vo model da vidis za sho zboram :)) 
- Pri create na ticket da se dodade mehanizam da postojka pocetna, krajna i avtobus, so dropdaun listi
- Kaj izlistanite busStops da se dodade kopche rezerviraj Tiket shto kje ne prenasochi kon pop up (so partial view) kade shto pochetnata stanica kje bide selektiranata i kje mozhe so drop down lista da se izbere krajnata postojka za koja kreirame bilet. Otkako kje se izberat postojkite da se izlistaat site vtobusi koi pominuvaat niz tie dve postojki za korisnikot da mozhe da izbere. Otkako kje izbere dopolnitelno se izlistuvaat i vreminjata koga avtobusot pominuva od prvata postojka (kje gi izlista samo vreminjata kade shto ima prazno mesto vo avtobusot). Otkako se kje izbere da ima opcija reserve i cancel
- Sreduvanje na delot User - Kadeso ke se dodade funkcionalnost dodavanje ticket na userot 

[Priority: Normal]
- Da ovozmozime prikazuvanje na cela lista avtobusi vo Details na BusStop, isto taka cela lista BusStops vo Details na avtobusi
- dodadi userRoles vo baza
- da se smeni kaj bus klasata start time da ne bide DateTime tuku samo string koj kje se vnesuva vo odreden format (so validate). ?? Dali ova da e vaka?? zborime u pon
- da se napravi logikata za tocno rezerviranje ticket
- restrikcii koj mozhe shto da gleda (korisnikot da mozhe samo da lista i da rezervira tiketi a administratort da mozhe da dodava i da pravi edit)
- administratorot da ima log od site tickets koi se napraveni
- Da dodademe JqueryDataTables nasekade
- Da gi nashminkame stranite so Bootstrap
 
 
 [DONE]
 - da se napravi ticket klasata 
 - dodaden tiket kontroler
 - pri registracija da bara dopolnitelno Ime i prezime za koga kje go otvorish profilot da pishuva Hello Ime Prezime :)
 - Sreduvanje na delot User -imanje profil [so ime prezime,tabela tickets]
 - gore vo menito mestoBuslines da se izlistuvaat site tiketi (za da gledame kako raboti a posle ova kje bide vidlivo samo za admin)
