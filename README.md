<h1 align="center">Négymuskétás<br/>Pizzéria projekt dokumentáció</h1>


## MainWindow(bejelentkezés):

### Tagváltozók és tulajdonságok:
•	connectionString: Az adatbázis kapcsolat stringje, amely tartalmazza a szerver elérhetőségét, a portszámot, a felhasználónevet, a jelszót és az adatbázis nevét.

•	connection: MySQL adatbázis kapcsolat objektuma, amely lehetővé teszi a lekérdezések végrehajtását.

•	users: Felhasználókat tartalmazó lista, amelybe az adatbázisból lekért felhasználói adatok kerülnek.

•	Bejelentkezett: A bejelentkezett felhasználót reprezentáló tulajdonság, amely a sikeres bejelentkezés után kerül beállításra.
### Fő metódusok:
loadUsers()
Ez a metódus az adatbázisból lekéri a felhasználói adatokat, és hozzáadja azokat a users listához.
1.	Adatbázis kapcsolat: A MySQL adatbázis csatlakozását végzi el a connectionString alapján.
2.	Lekérdezés: Az adatbázisból egy SELECT lekérdezés segítségével minden felhasználói adatot kinyer.
3.	Adatok beolvasása: A lekérdezés eredménye egy MySqlDataReader segítségével kerül feldolgozásra, és a users listába adódik hozzá.
4.	Hiba kezelés: Ha bármilyen hiba történik, egy üzenet jelenik meg a felhasználónak a MessageBox.Show() segítségével.
checkUser()
Ez a metódus felel a bejelentkezési logikáért, amely ellenőrzi a felhasználónév és jelszó helyességét.
1.	Felhasználónév és jelszó ellenőrzése: A metódus végignézi a felhasználók listáját, és összehasonlítja az űrlapon megadott felhasználónevet és jelszót az adatbázisból lekért adatokkal.
2.	Adminisztrátor bejelentkezés: Ha az adott felhasználó adminisztrátori jogosultságokkal rendelkezik, akkor az admin felületet nyitja meg.
3.	Sikeres bejelentkezés: Ha a felhasználó nem admin, de a név és a jelszó egyezik, akkor a rendelési felületet nyitja meg.
4.	Hibás bejelentkezés: Ha a név és jelszó páros nem megfelelő, hibaüzenet jelenik meg, például ha csak a jelszó vagy a felhasználónév hibás.
btnBejelentkezes_Click()
Ez a metódus a bejelentkezés gomb (btnBejelentkezes) megnyomására fut le, és elindítja a felhasználó ellenőrzési folyamatot a checkUser() metódus segítségével.
btnRegisztracio_Click()
Ez a metódus a regisztráció gomb (btnRegisztracio) megnyomására nyitja meg a regisztrációs ablakot, majd bezárja a főablakot.
input_KeyDown()
Ez egy eseménykezelő, amely figyeli a billentyűlenyomásokat az adott beviteli mezőkben (felhasználónév és jelszó). Ha az "Enter" billentyűt nyomja le a felhasználó, elindítja a bejelentkezési folyamatot.
Border_MouseLeftButtonDown()
Ez a metódus a felület egy határának kattintására engedélyezi az ablak húzását (ablak áthelyezését), így az alkalmazás nem csak a hagyományos ablak címsávján keresztül mozgatható.



## RegistrationWindow(regisztáció):
### Tagváltozók és tulajdonságok:
•	connectionString: Az adatbázis kapcsolat stringje, amely tartalmazza az adatbázis szerverének IP címét, portszámát, felhasználónevet, jelszót és az adatbázis nevét.
•	connection: MySQL adatbázis kapcsolat objektum, amely a lekérdezések végrehajtásáért felel.
•	users: Felhasználók listája, amely tartalmazza az adatbázisból lekért felhasználói adatokat.
•	vanHiba: Logikai változó, amely jelzi, hogy a regisztráció során történt-e hiba.
•	hibaÜzenet: A hibaüzenetek tárolására szolgál, amelyeket a felhasználónak jelenít meg.
•	nev, email, cim, jelszo, telefon, status: A felhasználó által megadott adatok tárolására szolgáló változók.

### Fő metódusok:
checkRegistration()
Ez a metódus felelős a regisztrációs adatok ellenőrzéséért és az esetleges hibák megjelenítéséért.
1.	Adatok lekérése: Az űrlapon megadott felhasználói adatok (név, email, cím, jelszó, telefon) lekérése.
2.	Adatellenőrzés: Ellenőrzi, hogy:
o	A felhasználónév már létezik-e.
o	A jelszó legalább 8 karakter hosszú-e.
o	A telefonszám helyes-e (legalább 12 karakter hosszú és + jellel kezdődik).
o	Az email cím már létezik-e vagy helyes-e a formátuma (Regex ellenőrzés).
o	A címmező nem üres-e.
3.	Státusz meghatározása: Ha az "Admin" jelölőnégyzet be van jelölve, akkor adminisztrátori státuszt állít be, egyébként felhasználói státuszt (User).
4.	Hibák megjelenítése: Ha hiba történt, a hibaÜzenet változóban felhalmozott hibaüzeneteket jeleníti meg egy MessageBox segítségével.
userUpload()
Ez a metódus a felhasználói adatokat tölti fel az adatbázisba, miután a regisztrációs ellenőrzés megtörtént.
1.	Adatbázis kapcsolat: Új MySQL kapcsolat nyílik meg.
2.	Lekérdezés összeállítása: A felhasználói adatokat egy INSERT SQL utasítással adja hozzá az adatbázis accounts táblájához.
3.	Paraméterek hozzáadása: Az SQL lekérdezés paraméterezése (név, jelszó, telefon, email, cím, státusz) az űrlapon megadott értékek alapján.
4.	Lekérdezés végrehajtása: Az adatbázisba írás a ExecuteNonQuery() metódussal történik.
btnRegister_Click()
Ez az eseménykezelő felel a regisztrációs gomb (btnRegister) kattintására végrehajtott műveletekért.
1.	Regisztráció ellenőrzése: Elindítja a checkRegistration() metódust, amely ellenőrzi az adatokat.
2.	Adatok feltöltése: Ha nem volt hiba az ellenőrzés során, a userUpload() metódus végrehajtja az adatok adatbázisba írását.
3.	A főablak megnyitása: Sikeres regisztráció után megnyitja a fő ablakot, és bezárja a regisztrációs ablakot.
Button_Click()
Ez az eseménykezelő a "Vissza" gomb (Button) kattintására lép életbe, amely bezárja a regisztrációs ablakot, és visszaviszi a felhasználót a főablakba.
### Adatbázis struktúra:
•	A felhasználói adatok a accounts táblába kerülnek mentésre. A tábla mezői: Account_Id, Username, Password, Mobil, Email, Address, Status, Registration_Date.
### Validációs szabályok:
1.	Felhasználónév: Nem lehet üres, és nem lehet már létező felhasználónév.
2.	Jelszó: Legalább 8 karakter hosszú kell, hogy legyen.
3.	Telefonszám: Legalább 12 karakter hosszú, és + jellel kell kezdődnie.
4.	Email: Nem lehet üres, és helyes formátumúnak kell lennie (Regex ellenőrzés).
5.	Cím: Nem lehet üres.


## AdminPage:
### Fő funkciók:
1.	Alapanyagok betöltése az adatbázisból:
o	A Beolvasas nevű lambda-függvény betölti az alapanyagokat (ingredients) a MySQL adatbázisból. Az eredményt egy ObservableCollection tárolja, amely frissíti a felhasználói felületet (adatkötés használatával) a dgAlapanyagok DataGrid-ben.
2.	Alapanyag módosítása:
o	A btnModositas eseménykezelő beállítja a kiválasztott alapanyagot, majd egy külön gomb (btnModosit) segítségével lehet módosítani az adatokat. Az adatbázis frissül a megfelelő SQL UPDATE lekérdezéssel, majd a DataGrid is frissítésre kerül.
3.	Új alapanyag felvétele:
o	A btnFelvetel eseménykezelő lehetővé teszi új alapanyag hozzáadását az adatbázishoz. Az SQL INSERT INTO utasítással történik az új adatok beszúrása. Ezenkívül a rendszer automatikusan frissíti azokat a pizzákat, amelyek tartalmazzák az új alapanyagot, és a készlet státuszát elérhetővé teszi.
4.	Alapanyag törlése:
o	A btnTorles eseménykezelő törli a kiválasztott alapanyagot. Az SQL DELETE lekérdezés eltávolítja az alapanyagot az adatbázisból, és a kapcsolódó pizzákat nem elérhető státuszra állítja.
5.	TextBox és DataGrid események kezelése:
o	Van egy korlátozás az alapanyag nevének hosszára a tbAlapanyagNev TextBox-ban (maximum 10 sor).
o	A NumberValidationTextBox biztosítja, hogy a mennyiséghez csak numerikus értéket lehessen bevinni.
### Kiválasztás és állapotkezelés:
•	A kiválasztott alapanyagot a kivalasztottAlapanyag nevű változó tárolja, amely az adott alapanyagra mutat. A kiválasztott sor módosítása, törlése ezzel a változóval történik.
### Hibakezelés:
•	Minden adatbázis művelet try-catch blokkokkal van körülvéve, hogy a felhasználót értesíthesse, ha valami hiba történik az adatbázis műveletek során (pl. nem sikerül a csatlakozás vagy a lekérdezés).
### Felhasználói felület események:
•	DragMove: Az ablak mozgatását biztosítja, ha a felhasználó a keretet húzza.
•	Logout: A kijelentkezési esemény lezárja az AdminPage-et és megnyitja a fő ablakot (MainWindow).







## Rendelés
### A főbb funkciók és folyamatok:
1.	Adatbázis kapcsolat és pizzák betöltése: A program MySQL kapcsolatot hoz létre az adatbázissal, majd lekéri a pizzák adatait a foods táblából. Minden pizza adatait egy Pizza objektumba helyezi, amelyet a felhasználói felületen listáz.
2.	Pizzák kiválasztása és kosár kezelése:
o	A felhasználók kiválaszthatják a rendelkezésre álló pizzákat, amelyeket a kosárba helyeznek.
o	A kosárba helyezett pizzák külön StackPanel-ekben jelennek meg, és a pizzák ára hozzáadódik a végösszeghez.
o	A kiválasztott pizzák kosárból való eltávolítása is lehetséges.
3.	Pizzarészletek megjelenítése:
o	Amikor a felhasználó egy pizzára kattint, a pizza részletei (név, hozzávalók, ár) megjelennek a felületen.
o	A program megjeleníti a pizza képét is a megfelelő kép helyi fájlstruktúrából.
4.	Rendelés leadása:
o	Amikor a felhasználó leadja a rendelést, a rendszer ellenőrzi, hogy a kosár nem üres, majd felkínálja a rendelés jóváhagyását.
o	Ha a felhasználó jóváhagyja a rendelést, a végösszeg és a borravaló összege alapján elküldi a rendelést.
5.	Email küldése rendelésről:
o	A program a rendelés jóváhagyása után egy visszaigazoló emailt küld a felhasználónak, amely tartalmazza a rendelés részleteit, mint például a felhasználó neve, szállítási címe, a fizetendő összeg és elérhetősége.
o	Az emailküldést az SMTP protokoll segítségével hajtja végre a Gmail szerverén keresztül.
6.	Felhasználói adatok előtöltése:
o	A bejelentkezett felhasználó adatai, mint például a telefonszám és a szállítási cím, automatikusan előtöltődnek a megfelelő mezőkbe, ezzel is megkönnyítve a rendelés leadását.
### Kód főbb pontjai:
•	MySQL kapcsolat: Az alkalmazás MySQL adatbázis kezelésére a MySqlConnection objektumot használja, amelyhez egy string formátumú kapcsolatstruktúrában adja meg az adatbázis elérési adatait.<br/>
•	Pizzák megjelenítése: A pizzák adatai a lekérdezés után külön-külön megjelennek a felhasználói felületen, és ezek közül a felhasználók szabadon választhatnak.<br/>
•	Kosár kezelés: Az ObservableCollection-t használja a kosárban lévő pizzák dinamikus megjelenítéséhez. A felhasználó könnyen hozzáadhat vagy eltávolíthat pizzákat.<br/>
•	SMTP email küldés: Az emailküldéshez az SMTP protokollt használja, ahol a rendelés adatai, például a felhasználó neve és címe, szerepelnek.
## Feladatkörök:
Barizs Márton Dániel: Frontend és a hozzá tartozó backend<br/>
Beke Tamás: Backend(Pizza osztály, AdminPage, Rendelés), Adatbázis<br/>
Gajdos Csanád: Backend(Bejelentkezés, regisztráció, User osztály, email küldés), anyaggyűjtés, dokumentáció<br/>
Hernádi Balázs: Adatbázis, AdminPage kezdetleges frontend(full reworköltük)
