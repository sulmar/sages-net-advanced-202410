# Eksport klasy do pliku CSV 

## Cel
Twoim zadaniem jest napisanie klasy w C#, która umożliwi eksport danych dowolnej klasy do pliku CSV. Klasa ta powinna być uniwersalna, tak aby mogła przyjąć obiekt dowolnego typu i na tej podstawie stworzyć plik CSV z wartościami pól tego obiektu.


## Wymagania:
1. **Główna klasa eksportu do CSV:**
- Nazwa klasy: `CsvExporter<T>`
- Klasa powinna być generyczna i działać dla dowolnego typu `T`.
- Metoda główna: `void ExportToCsv(IEnumerable<T> data, string filePath)`


  - Parametry:
		- `data`: Kolekcja obiektów klasy `T`, które mają być eksportowane do CSV.
		- `filePath`: Ścieżka do pliku, gdzie zapisany zostanie wynikowy plik CSV.
	- Działanie metody:
		- Metoda powinna analizować właściwości klasy `T` i na ich podstawie tworzyć nagłówki kolumn w CSV.
		- Powinna zapisywać wartości właściwości każdego obiektu z kolekcji data jako nowy wiersz w pliku CSV.


2. **Format pliku CSV:**
	- Pierwszy wiersz pliku CSV powinien zawierać nazwy właściwości klasy `T` jako nagłówki kolumn.
	- Każdy kolejny wiersz powinien zawierać wartości właściwości danego obiektu z kolekcji data.
	- Wartości powinny być rozdzielone przecinkami.


3. **Przykład użycia:** Klasa powinna być łatwa w użyciu. Oto przykładowy scenariusz, gdzie klasa jest używana do eksportu danych:

```cs
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

// Użycie klasy CsvExporter
var people = new List<Person>
{
    new Person { FirstName = "John", LastName = "Doe", Age = 30 },
    new Person { FirstName = "Jane", LastName = "Smith", Age = 25 }
};

var exporter = new CsvExporter<Person>();
exporter.ExportToCsv(people, "people.csv");
```

4. **Dodatkowe wymagania:**
Użyj refleksji w C# do automatycznego odczytania nazw właściwości i ich wartości.
Obsługa typów zagnieżdżonych lub kolekcji powinna być w zakresie minimalnym (np. można ignorować złożone obiekty lub reprezentować je w jednej kolumnie).