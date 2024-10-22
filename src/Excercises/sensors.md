# System monitorowania czujników 

## Opis
Tworzymy system, który będzie wykorzystywany w zarządzaniu budynkiem lub fabryką, gdzie różne czujniki monitorują warunki środowiskowe a raporty umożliwiają monitorowanie konkretnych parametrów, takich jak temperatura, wilgotność, ciśnienie itp.

W systemie tym różne czujniki mogą zwracać różne typy danych:
- temperaturę jako `double`
- wilgotność jako `int`
- status czujnika ruchu jako `bool`

Czujnik powinien mieć nazwę (Name), zwracać aktualną wartość (Value) i datę ostatniej aktualizacji danych (LastUpdated).
Wartość powinna być aktualizowana losowo za pomocą metody `UpdateValue()`

## Zadanie
Utwórz **wspólną listę czujników** różnych typów i dodaj możliwość generowanie raportu dla czujników we wspólnej liście w postaci:

```
Sensor: Temperature Sensor, Value: 21.9, Last Updated: 2024-10-22 9:45:00
Sensor: Humidity Sensor, Value: 55, Last Updated: 2024-10-22 9:55:00
Sensor: Motion Sensor, Value: True, Last Updated: 2024-10-22 9:59:00
```


