# ManyPages 

ManyPages — это проект на C# (Avalonia UI), демонстрирующий переходы между несколькими страницами и работу с элементами интерфейса в приложении.

---

## Описание проекта

Проект показывает:
- использование UserControl для экранов;
- реализацию навигации между страницами;
- отображение списка элементов с поддержкой ScrollViewer.

> "_Минимализм и структурность — основа хорошего интерфейса._"

---

## Основные возможности

1. Многостраничная структура
   - Каждый экран — отдельный UserControl.
2. Навигация
   - Используется класс Frame для переключения страниц.
3. Интерфейс
   - Поддерживается скроллинг элементов.

---

### Форматирование текста

- *курсивный текст*  
- жирный текст  
- *жирный курсив*  
- зачёркнутый  
- <u>подчёркнутый</u>  
- _жирный курсив подчёркнутый_

---
## Структура проекта

| Файл / Папка | Описание |
|---------------|-----------|
| MainWindow.axaml | Главное окно |
| Pages/ | Раздел с экранами |
| ViewModels/ | ViewModel-слой |
| App.axaml | Настройки приложения |
| README.md | Документация проекта |

---

## Используемые технологии

- C#  
- Avalonia UI  
- MVVM  
- XAML  

---

### Чек-лист

- [x] Создано несколько страниц  
- [x] Настроена навигация  
- [x] Добавлен ScrollViewer  
- [ ] Добавить анимацию переходов  
- [ ] Реализовать сохранение состояния  

---

## Пример кода

```
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
  <Grid>
    <TextBlock Text="Добро пожаловать в ManyPages!" 
               FontSize="24"
               HorizontalAlignment="Center"
               VerticalAlignment="Center"/>
  </Grid>
</UserControl>
```

## Ссылки
 • [Avalonia UI документация](https://docs.avaloniaui.net/)
 • [C# .NET документация](https://learn.microsoft.com/dotnet/)


![Изображение](https://github.com/user-attachments/assets/0afc8bb7-7aa5-4107-9c61-5e3292e417ee)

![Изображение](https://github.com/user-attachments/assets/55235b81-9089-45e8-801c-84d6069d656c)

![Изображение](https://github.com/user-attachments/assets/1d790ded-8d6a-4071-a936-6349e1237b49)
