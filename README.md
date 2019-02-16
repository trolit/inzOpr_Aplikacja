# Aplikacja webowa - "Obsługa Imprez Masowych" 
#### aplikacja wykonana jako projekt ASP.NET MVC4 w programie VS 2017 Community na przedmiot Inżynieria Oprogramowania

<details><summary>:movie_camera: Zrzuty ekranu z aplikacji (wersja 0.7)</summary>
<p align="center">
  <img src="https://github.com/trolit/inzOpr_Aplikacja/blob/master/images/client.PNG" height="350" /><br/>
  <img src="https://github.com/trolit/inzOpr_Aplikacja/blob/master/images/main.PNG" height="350" /> <br/>
  <img src="https://github.com/trolit/inzOpr_Aplikacja/blob/master/images/worker1.PNG" height="350" /> <br/>
  <img src="https://github.com/trolit/inzOpr_Aplikacja/blob/master/images/worker2.PNG" height="350" />
</p>
</details>

<details><summary>:information_source: Wersja 0.7 z dnia 22 stycznia 2019 roku</summary>
<p>
	<h3>Autorzy i zasługi</h3>
	<ul>
		1. Paweł Idzikowski
		<ul>
				<li>opracowanie aplikacji od strony backendu</li>
		</ul>	
		2. Dorota Gil
		<ul>
				<li>opracowanie frontendu dla aplikacji</li>
		</ul>
		3. Damian Gnatkowski
		<ul>
				<li>przetłumaczenie aplikacji</li>
				<li>testowanie aplikacji</li>
		</ul>
		4. Maciej Kozikowski
		<ul>
				<li>testowanie aplikacji</li>
		</ul>
	<ul>

<br/>

<details><summary>Wprowadzone funkcjonalności</summary>
:heavy_check_mark: zapisywanie się na imprezę jako "Uczestnik imprezy" <br/>
:heavy_check_mark: wysyłanie zgłoszenia o organizację imprezy z panelu "Klienta" <br/>
:heavy_check_mark: dodawanie do projektów informacji o Personel/Dokumentacja/Personel <br/>
:heavy_check_mark: akceptowanie/odrzucenie zgłoszeń <br/>
:heavy_check_mark: autoryzowanie dostępu do sekcji Przełożony/Pracownik <br/>
:heavy_check_mark: filtrowanie pozwoleń/dokumentacji/personelu, które tyczą się danego projektu <br/>
:heavy_check_mark: zarządzanie imprezami(bez tworzenia) <br/>
:heavy_check_mark: wgląd w uczestników, którzy zapisali się na dane imprezy<br/>
</details>

</p>
</details>



<details><summary>:information_source: Wersja 0.8 z dnia 09 luty 2019 roku</summary>
<p>
	<h3>Autorzy i zasługi</h3>
	<ul>
		1. Paweł Idzikowski
		<ul>
				<li>backend</li>
		</ul>	
	<ul>

<br/>

<details><summary>Wprowadzone funkcjonalności</summary>
:heavy_check_mark: usunięcie zgłoszenia powoduje usunięcie elementów powiązanych w Pozwolenia/Dokumentacja/Personel <br/>
:heavy_check_mark: wyświetlanie danych z bazy w postaci kart Boostrapa 4 <br/>
:heavy_check_mark: wprowadzenie trybu wyszukiwania w liście uczestników (widok - Uczestnicy_Lista) <br/>
:heavy_check_mark: wprowadzenie okruszków z Bootstrapa 4 <br/>
:heavy_check_mark: akceptacja projeku wymaga teraz tylko kliknięcia przycisku(a nie jak poprzednio edycji projektu i wpisania odpowiedniej nazwy) <br/>
:heavy_check_mark: dodanie panelu wiadomości i zaproponowanie szablonu w jaki mogłyby być wyświetlane "newsy" <br/>
:heavy_check_mark: dodanie panelu kontaktu - możliwość wysłania wiadomości do firmy. Przełożony może te wiadomości odczytać <br/>

~~Uwaga. W trakcie testowania napotkano usterke - przy tworzeniu zgłoszenia czy wiadomości data wysłania nie jest generowana. (do poprawienia)~~

Łatka: 16.02.2019 - data generowana jest już poprawnie. Dodany również został licznik znaków do pisanej wiadomości informujący osobę o tym ile 
pozostało znaków do wykorzystania. Uzupełniony został także design w postaci kart w widokach CreatePozwolenie, CreateDokumentacja i CreatePersonel.
Usunięto ograniczenie szerokości dla "inputów".

</details>

</p>
</details>