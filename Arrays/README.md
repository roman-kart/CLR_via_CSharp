# Массивы
CLR поддерживает:
- одномерные (single-demension)
```
int[] didits = new int[10];
```
- многомерные (multidemesion)
```
int[,] digits2 = new int[10, 20];
```
- нерегулярные (jagged)
```
int[][] digitsJagged = new int[3][]; // массив массивов
```

Массивы всегда размещаются в куче. Базовым для всех массивов является тип System.Array.
[!Размещение массива в куче](./imgReadme/arr_heap_1.png)

## Инициализация элементов массива
String[] names = new String[] { "Aidan", "Grant" };
