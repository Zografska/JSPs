# JSPs
Dobrodojdovte vo svetot na taskovite :)
Ke napisham nekolku rabotki so treba nekoj od nas da gi sredi :0
Dosega, kreeirani se osnovnite CRUD operacii, za site modeli potrebni za applikacijata e kreiran kontroler

Raboti so preostanuvaat:
[Priority: High]
- On Select javaScript function za da se izlistuvaat vreminjata za avtobusot i negovite postojki[Jana]

[Priority: Normal]
- Kaj user da ne vika Hloo janaser... hello Jana (firstname) [Zogra+Ognen]
- avtorizacija (administratorot da ima log od site tickets koi se napraveni, restrikcii koj mozhe shto da gleda (korisnikot da mozhe samo da lista i da rezervira tiketi a administratort da mozhe da dodava i da pravi edit))

[Posledno na kraj]
- Da gi nashminkame stranite so Bootstrap [Jana+Zogra ako ima vreme na kraj]
 
 [DONE]
 - Vo details za BusStop ne se izlistuvaat avtobusite na postojkata [Zogra+Ognen]
 - Broj na avtobus i data na rezervacija vo Index na TicketsController [Zogra+Ognen to su srca dva]
 - Da ne stoi Index ko naslov [Jana]
 - kaj izlistuvanje na tickets za korisnikiot time 12:00 Am da se trgne [Ognen]
 - da se napravi ticket klasata 
 - dodaden tiket kontroler
 - pri registracija da bara dopolnitelno Ime i prezime za koga kje go otvorish profilot da pishuva Hello Ime Prezime :)
 - Sreduvanje na delot User -imanje profil [so ime prezime,tabela tickets]
 - gore vo menito mestoBuslines da se izlistuvaat site tiketi (za da gledame kako raboti a posle ova kje bide vidlivo samo za admin)
 - Da dodademe JqueryDataTables nasekade 
 - dodadi userRoles vo baza [AMA KJE MORA PRI SEKOJ PULL NA NOVO DA SE DODAVAAT TAKA SHTO MANJE VISHE TREBA SAMO NA KRAJ KOA KJE GI STAIME RESTRIKCIITE DA GI SHIBNEME]
 - kreirana klasata BusLine za da gi lista site linii i dodadeno i e JqueryDataTables
 - kaj listanjeto na liniite kreiran nov Action Link koj kje gi izlistuva site avtobusi i nivnite vreminja na trganje za taa linija
 - kreirano i view za pregled na site avtobusi SeeBuses, kreirano i kako kje izlistuva view-to i dodadeni se jQueryDataTables
 - da se smeni kaj bus klasata start time da ne bide DateTime tuku samo string koj kje se vnesuva vo odreden format (so validate). ?? Dali ova da e vaka?? zborime u pon
 - kreirani DropDown listi pri kreiranje na tiket 
 - kaj SeeBuses view-to dodadena kolona za maksimalen kapacitet na avtobusot i preostanati mesta, ako ima dovolno mesto i saatot e ok(primer ako avtobusot trga vo 12:00 ti mozesh samo pred 12 da rezerviras) se pojavuva kopche za rezervacija na bilet za toj den (te prenasochuva kon view CreateDaily)
 - kas SeeBuses plus nov ActionLink za kreiranje na bileti za drugi denovi, napravena e drop down lista za liniite 
 - napraveno novo View koe kje se pokazhuva ako ima obid za kreiranje nov bilet a korisnikot ne e najaven (toa posle ima action link do log in stranata)
 - Pri create na ticket da se dodade mehanizam da postojka pocetna, krajna i avtobus, so dropdaun listi [Dodaden CreateTicketModel]
 - Ne znam zoso vo Bus Controller vo Details akcijata koa ke probam da pristapam do busStops atributot na Bus dobivam prazna lista, iako vo BusStopBus tabelata se pokazuvaat BusStopsot povrzani so toj bus. Istoto vazi i izlistuvanje na Buses vo BusStop details :)
- Pri create na bus stop da se dodade mehanizam da dodavanje poveke avtobusi koiso se vekje vo databazata (Odi vo busStops, probaj da kreirash postojka, i sporedi so podatoci vo model da vidis za sho zboram :))  --Reseno preku route funkcijata vo busses controler
-Details na ticket da gi prikaze krajnata destinacija i pocetnata 
- Sreduvanje na delot User - Kadeso ke se dodade funkcionalnost dodavanje ticket na userot 
- Da ovozmozime prikazuvanje na cela lista avtobusi vo Details na BusStop, isto taka cela lista BusStops vo Details na avtobusi (formata e napravena ama ne gi vleche podatocite)
- Vo Create view-to za tiketi da se napravat drop down listita za izbiranje na avtobus za linijata [listi napraveni podatoci ne se zemaat]
- Vo Create view-to za tiketi da se napravat drop down listite da vlechat soodvetni podatoci [listi napraveni podatoci ne se zemaat]
-Zogra: Vo index Tickets dodadov action linkovi za da nosat kon Details soodvetniot avtobus, postojka - no ne raboti. Ne ja izbira tocnata pateka? ne znam zoso. Kodot so go imav ex. @Html.ActionLink(ticket.Bus.BusNo, "Details", "Buses", new {id = ticket.Bus.ID}),,, Error: Bad request - me prenasocuvase na pateka na tickets kontrolerot....
- Kaj izlistanite busStops da se dodade kopche rezerviraj Tiket shto kje ne prenasochi kon create ticket
- kaj izlistuvanjeto tiketi da se dodadat koloni kako na primer za koja linija koj avtobus i vo kolku saat trgal avtobusot
- kaj dateTime pickerot za kreiranje nov bilet da se napravi da ne mozhe vo minatoto da se rezervira tiket- odnosno da se dodade kalendar kako datepicker od koj moze da se odbere datum
