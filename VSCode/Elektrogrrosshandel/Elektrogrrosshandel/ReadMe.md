### Login:
 
 Es sind 3 Benutzer vordefiniert:
 
 --- Username: a Password: a Rolle: Admin
 --- Username: b Password: b Rolle: User
 --- Username: c Password: c Rolle: User

 Es können weitere Benutzer angelegt werden.
 Diese sind nach Logout aus dem Main Menü gespeichert und stehen dann bei erneutem Login zur Verfügung.

 Zur erstellung eines neuen Benutzers einfach im Login Fenster auf "Neuen Benutzer erstellen" klicken und die Daten eingeben.
 
 Serialnummer Logik:

  --- Jede % 2 == 0  ist ein Admin Benutzer
  --- Jede % 3 == 0 && != % 2 ist ein Buissness Benutzer
  --- Jede andere ist ein User Benutzer


  ### Artikel:

  Es gibt 5 vordefinierte Artikel pro Kategorie:
  --- CPU
  --- GPU
  --- Mainboard
  --- RAM
  --- Speicher
  --- Netzteil
  --- Gehäuse
  --- Kühlung
  --- Zubehör
  --- Monitor
  --- Peripherie
  --- Software

  Diese werden bei erstem Start der Anwendung automatisch angelegt.
  Es können weitere Artikel angelegt, bearbeitet und gelöscht werden.
  Die Artikel sind in einer Liste dargestellt und können über die Suchfunktion gefiltert werden.
  Nach dem Anlegen, Bearbeiten oder Löschen eines Artikels wird die Liste automatisch aktualisiert.

  ### Warenkorb:

  Es können Artikel in den Warenkorb gelegt werden.
  Der Warenkorb ist im Main Menü über den Button "Warenkorb" erreichbar.
  Im Warenkorb können Artikel entfernt werden.
  Der Gesamtpreis wird automatisch aktualisiert.
  Der Warenkorb wird nach dem Logout geleert.

  Beim speichern eines Warenkorbs wird der aktuelle Warenkorb in der Datenbank gespeichert und ein neuer leerer Warenkorb erstellt.