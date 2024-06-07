using System;
using System.Collections;
using System.Collections.Generic;

// Власний клас винятків для музичного каталогу
public class MusicCatalogException : Exception
{
    // Конструктор для ініціалізації повідомлення про помилку
    public MusicCatalogException(string message) : base(message) { }
}

// Власний клас винятків для випадку, коли диск вже існує
public class DiscAlreadyExistsException : MusicCatalogException
{
    // Конструктор для ініціалізації повідомлення про помилку
    public DiscAlreadyExistsException(string message) : base(message) { }
}

// Власний клас винятків для випадку, коли диск не знайдено
public class DiscNotFoundException : MusicCatalogException
{
    // Конструктор для ініціалізації повідомлення про помилку
    public DiscNotFoundException(string message) : base(message) { }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Виклик методу для обробки каталогу музики
            HandleMusicCatalog();
        }
        catch (MusicCatalogException ex)
        {
            // Обробка власних винятків каталогу музики
            Console.WriteLine($"MusicCatalogException: {ex.Message}");
        }
        catch (ArrayTypeMismatchException ex)
        {
            // Обробка винятку невідповідності типів масиву
            Console.WriteLine($"ArrayTypeMismatchException: {ex.Message}");
        }
        catch (DivideByZeroException ex)
        {
            // Обробка винятку ділення на нуль
            Console.WriteLine($"DivideByZeroException: {ex.Message}");
        }
        catch (IndexOutOfRangeException ex)
        {
            // Обробка винятку виходу за межі індексу масиву
            Console.WriteLine($"IndexOutOfRangeException: {ex.Message}");
        }
        catch (InvalidCastException ex)
        {
            // Обробка винятку невірного перетворення типів
            Console.WriteLine($"InvalidCastException: {ex.Message}");
        }
        catch (OutOfMemoryException ex)
        {
            // Обробка винятку недостатньої пам'яті
            Console.WriteLine($"OutOfMemoryException: {ex.Message}");
        }
        catch (OverflowException ex)
        {
            // Обробка винятку переповнення
            Console.WriteLine($"OverflowException: {ex.Message}");
        }
        catch (StackOverflowException ex)
        {
            // Обробка винятку переповнення стека
            Console.WriteLine($"StackOverflowException: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Обробка інших винятків
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }

    private static void HandleMusicCatalog()
    {
        // Створення об'єкту каталогу музики
        MusicCatalog catalog = new MusicCatalog();

        // Демонстрація винятку ArrayTypeMismatchException
        try
        {
            object[] objArray = new string[1]; // Створення масиву рядків
            objArray[0] = 1; // Генерує ArrayTypeMismatchException
        }
        catch (ArrayTypeMismatchException ex)
        {
            // Вивід повідомлення про помилку
            Console.WriteLine($"ArrayTypeMismatchException: {ex.Message}");
        }

        // Демонстрація винятку DivideByZeroException
        try
        {
            int zero = 0; // Ініціалізація змінної нулем
            int result = 1 / zero; // Генерує DivideByZeroException
        }
        catch (DivideByZeroException ex)
        {
            // Вивід повідомлення про помилку
            Console.WriteLine($"DivideByZeroException: {ex.Message}");
        }

        // Демонстрація винятку IndexOutOfRangeException
        try
        {
            int[] array = new int[1]; // Створення масиву з одним елементом
            int outOfBounds = array[2]; // Генерує IndexOutOfRangeException
        }
        catch (IndexOutOfRangeException ex)
        {
            // Вивід повідомлення про помилку
            Console.WriteLine($"IndexOutOfRangeException: {ex.Message}");
        }

        // Демонстрація винятку InvalidCastException
        try
        {
            object str = "hello"; // Ініціалізація об'єкту рядком
            int invalidCast = (int)str; // Генерує InvalidCastException
        }
        catch (InvalidCastException ex)
        {
            // Вивід повідомлення про помилку
            Console.WriteLine($"InvalidCastException: {ex.Message}");
        }

        // Демонстрація винятку OutOfMemoryException
        try
        {
            // int[] largeArray = new int[int.MaxValue]; // Може генерувати OutOfMemoryException
        }
        catch (OutOfMemoryException ex)
        {
            // Вивід повідомлення про помилку
            Console.WriteLine($"OutOfMemoryException: {ex.Message}");
        }

        // Демонстрація винятку OverflowException
        try
        {
            checked
            {
                int max = int.MaxValue; // Ініціалізація змінної максимальним значенням int
                max += 1; // Генерує OverflowException
            }
        }
        catch (OverflowException ex)
        {
            // Вивід повідомлення про помилку
            Console.WriteLine($"OverflowException: {ex.Message}");
        }

        // Демонстрація винятку StackOverflowException
        try
        {
            // StackOverflow(); // Генерує StackOverflowException через рекурсію без базового випадку
        }
        catch (StackOverflowException ex)
        {
            // Вивід повідомлення про помилку
            Console.WriteLine($"StackOverflowException: {ex.Message}");
        }

        // Додавання диска до каталогу
        try
        {
            MusicDisc disc1 = new MusicDisc("Thriller", "Michael Jackson"); // Створення диска
            catalog.AddDisc(disc1); // Додавання диска до каталогу
            catalog.AddDisc(disc1); // Генерує власний виняток DiscAlreadyExistsException
        }
        catch (DiscAlreadyExistsException ex)
        {
            // Вивід повідомлення про помилку
            Console.WriteLine($"DiscAlreadyExistsException: {ex.Message}");
        }
    }

    // Метод для генерації StackOverflowException через рекурсію
    private static void StackOverflow()
    {
        StackOverflow(); // Рекурсія без базового випадку
    }
}

// Клас для каталогу музики
public class MusicCatalog
{
    private Hashtable catalog; // Зберігає каталог дисків

    public MusicCatalog()
    {
        catalog = new Hashtable(); // Ініціалізація каталогу
    }

    // Метод для додавання диска
    public void AddDisc(MusicDisc disc)
    {
        if (!catalog.Contains(disc.Title))
        {
            catalog.Add(disc.Title, disc); // Додаємо диск до каталогу
        }
        else
        {
            throw new DiscAlreadyExistsException("Disc already exists in the catalog."); // Генеруємо виняток, якщо диск вже існує
        }
    }

    // Метод для видалення диска
    public void RemoveDisc(string title)
    {
        if (catalog.Contains(title))
        {
            catalog.Remove(title); // Видаляємо диск з каталогу
        }
        else
        {
            throw new DiscNotFoundException("Disc not found in the catalog."); // Генеруємо виняток, якщо диск не знайдено
        }
    }

    // Метод для додавання пісні до диска
    public void AddSongToDisc(string discTitle, Song song)
    {
        if (catalog.Contains(discTitle))
        {
            MusicDisc disc = (MusicDisc)catalog[discTitle];
            disc.AddSong(song); // Додаємо пісню до диска
        }
        else
        {
            throw new DiscNotFoundException("Disc not found in the catalog."); // Генеруємо виняток, якщо диск не знайдено
        }
    }

    // Метод для видалення пісні з диска
    public void RemoveSongFromDisc(string discTitle, Song song)
    {
        if (catalog.Contains(discTitle))
        {
            MusicDisc disc = (MusicDisc)catalog[discTitle];
            disc.RemoveSong(song); // Видаляємо пісню з диска
        }
        else
        {
            throw new DiscNotFoundException("Disc not found in the catalog."); // Генеруємо виняток, якщо диск не знайдено
        }
    }

    // Метод для перегляду всього каталогу
    public void ViewCatalog()
    {
        foreach (DictionaryEntry entry in catalog)
        {
            MusicDisc disc = (MusicDisc)entry.Value;
            Console.WriteLine(disc); // Вивід інформації про диск
            foreach (var song in disc.Songs)
            {
                Console.WriteLine($"  - {song}"); // Вивід інформації про пісні
            }
        }
    }

    // Метод для перегляду конкретного диска
    public void ViewDisc(string title)
    {
        if (catalog.Contains(title))
        {
            MusicDisc disc = (MusicDisc)catalog[title];
            Console.WriteLine(disc); // Вивід інформації про диск
            foreach (var song in disc.Songs)
            {
                Console.WriteLine($"  - {song}"); // Вивід інформації про пісні
            }
        }
        else
        {
            throw new DiscNotFoundException("Disc not found in the catalog."); // Генеруємо виняток, якщо диск не знайдено
        }
    }

    // Метод для пошуку пісень та дисків по виконавцю
    public void SearchByArtist(string artist)
    {
        foreach (DictionaryEntry entry in catalog)
        {
            MusicDisc disc = (MusicDisc)entry.Value;
            if (disc.Artist == artist)
            {
                Console.WriteLine(disc); // Вивід інформації про диск, якщо виконавець збігається
            }

            foreach (var song in disc.Songs)
            {
                if (song.Artist == artist)
                {
                    Console.WriteLine($"  - {song}"); // Вивід інформації про пісню, якщо виконавець збігається
                }
            }
        }
    }
}

// Клас для музичних дисків
public class MusicDisc
{
    public string Title { get; set; } // Назва диска
    public string Artist { get; set; } // Виконавець
    public List<Song> Songs { get; set; } // Список пісень

    public MusicDisc(string title, string artist)
    {
        Title = title;
        Artist = artist;
        Songs = new List<Song>(); // Ініціалізація списку пісень
    }

    // Метод для додавання пісні
    public void AddSong(Song song)
    {
        Songs.Add(song);
    }

    // Метод для видалення пісні
    public void RemoveSong(Song song)
    {
        Songs.Remove(song);
    }

    public override string ToString()
    {
        return $"{Title} by {Artist}"; // Перевизначення методу для виведення інформації про диск
    }
}

// Клас для пісень
public class Song
{
    public string Title { get; set; } // Назва пісні
    public string Artist { get; set; } // Виконавець
    public double Duration { get; set; } // Тривалість пісні у хвилинах

    public Song(string title, string artist, double duration)
    {
        Title = title;
        Artist = artist;
        Duration = duration;
    }

    public override string ToString()
    {
        return $"{Title} by {Artist}, {Duration} min"; // Перевизначення методу для виведення інформації про пісню
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Song other = (Song)obj;
        return Title == other.Title && Artist == other.Artist && Duration == other.Duration; // Порівняння пісень
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Artist, Duration); // Генерація хеш-коду для пісні
    }
}
