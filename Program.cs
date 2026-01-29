using System;
using System.Globalization;

Console.WriteLine("=== CHƯƠNG TRÌNH XỬ LÝ CHUỖI VÀ MẢNG ===");
Console.WriteLine("PHẦN A - CHUỖI");
Console.WriteLine("1. Chuẩn hoá họ tên");
Console.WriteLine("2. Đếm số từ");
Console.WriteLine("3. Kiểm tra chuỗi đối xứng");
Console.WriteLine("PHẦN B - MẢNG");
Console.WriteLine("4. Tính tổng mảng số nguyên");
Console.WriteLine("5. Tìm giá trị lớn nhất");
Console.WriteLine("6. Đếm số phần tử chẵn");
Console.WriteLine("PHẦN C - CHUỖI + MẢNG");
Console.WriteLine("7. Tách họ tên thành mảng");
Console.WriteLine("8. Tìm từ dài nhất");
Console.WriteLine("9. Đếm chuỗi khác null trong mảng");
Console.Write("Chọn bài (1-9): ");

string choice = Console.ReadLine();

switch (choice)
{
    case "1":
        Console.Write("Nhập họ tên: ");
        string input1 = Console.ReadLine();
        string result1 = NormalizeFullName(input1);
        if (!string.IsNullOrWhiteSpace(result1))
        {
            Console.WriteLine("Họ tên chuẩn hoá: " + result1);
        }
        break;

    case "2":
        Console.Write("Nhập chuỗi: ");
        string input2 = Console.ReadLine();
        int count = CountWords(input2);
        Console.WriteLine("Số từ trong chuỗi: " + count);
        break;

    case "3":
        Console.Write("Nhập chuỗi: ");
        string input3 = Console.ReadLine();
        bool isPalindrome = IsPalindrome(input3);
        Console.WriteLine("Chuỗi đối xứng: " + (isPalindrome ? "Có" : "Không"));
        break;

    case "4":
        Console.Write("Nhập số phần tử (n): ");
        int n = int.Parse(Console.ReadLine());
        int[] arr4 = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Phần tử [{i}]: ");
            arr4[i] = int.Parse(Console.ReadLine());
        }
        int sum = SumArray(arr4);
        Console.WriteLine("Tổng mảng: " + sum);
        break;

    case "5":
        Console.Write("Nhập số phần tử (n): ");
        int n5 = int.Parse(Console.ReadLine());
        int[] arr5 = new int[n5];
        for (int i = 0; i < n5; i++)
        {
            Console.Write($"Phần tử [{i}]: ");
            arr5[i] = int.Parse(Console.ReadLine());
        }
        int max = FindMax(arr5);
        Console.WriteLine("Giá trị lớn nhất: " + max);
        break;

    case "6":
        Console.Write("Nhập số phần tử (n): ");
        int n6 = int.Parse(Console.ReadLine());
        int[] arr6 = new int[n6];
        for (int i = 0; i < n6; i++)
        {
            Console.Write($"Phần tử [{i}]: ");
            arr6[i] = int.Parse(Console.ReadLine());
        }
        int evenCount = CountEven(arr6);
        Console.WriteLine("Số phần tử chẵn: " + evenCount);
        break;

    case "7":
        Console.Write("Nhập họ tên: ");
        string input7 = Console.ReadLine();
        SplitFullName(input7);
        break;

    case "8":
        Console.Write("Nhập câu: ");
        string input8 = Console.ReadLine();
        string longestWord = FindLongestWord(input8);
        if (!string.IsNullOrWhiteSpace(longestWord))
        {
            Console.WriteLine("Từ dài nhất: " + longestWord);
        }
        break;

    case "9":
        Console.WriteLine("Nhập chuỗi (gõ 'done' để kết thúc):");
        string[] arr9 = new string[10];
        int index = 0;
        while (true)
        {
            Console.Write($"Chuỗi [{index}]: ");
            string input = Console.ReadLine();
            if (input.ToLower() == "done") break;
            arr9[index] = input;
            index++;
        }
        int nonNullCount = CountNonNullStrings(arr9);
        Console.WriteLine("Số chuỗi khác null và rỗng: " + nonNullCount);
        break;

    default:
        Console.WriteLine("Lựa chọn không hợp lệ!");
        break;
}

static string NormalizeFullName(string input)
{
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Lỗi: Họ tên không được để trống!");
        return "";
    }
    string trimmed = input.Trim();

    string[] words = trimmed.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
    for (int i = 0; i < words.Length; i++)
    {
        words[i] = textInfo.ToTitleCase(words[i].ToLower());
    }

    return string.Join(" ", words);
}

static int CountWords(string input)
{
    if (string.IsNullOrWhiteSpace(input))
    {
        return 0;
    }

    string trimmed = input.Trim();

    string[] words = trimmed.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    return words.Length;
}

static bool IsPalindrome(string input)
{
    if (string.IsNullOrWhiteSpace(input))
    {
        return false;
    }

    string cleaned = "";
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] != ' ')
        {
            cleaned += input[i];
        }
    }

    for (int i = 0; i < cleaned.Length / 2; i++)
    {
        if (char.ToLower(cleaned[i]) != char.ToLower(cleaned[cleaned.Length - 1 - i]))
        {
            return false;
        }
    }

    return true;
}

static int SumArray(int[] arr)
{
    if (arr == null)
    {
        Console.WriteLine("Lỗi: Mảng chưa được khởi tạo!");
        return 0;
    }

    int sum = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        sum += arr[i];
    }
    return sum;
}

static int FindMax(int[] arr)
{
    if (arr == null || arr.Length == 0)
    {
        Console.WriteLine("Lỗi: Mảng rỗng hoặc null!");
        return 0;
    }

    int max = arr[0];
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] > max)
        {
            max = arr[i];
        }
    }
    return max;
}

static int CountEven(int[] arr)
{
    if (arr == null)
    {
        return 0;
    }

    int count = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] % 2 == 0)
        {
            count++;
        }
    }
    return count;
}

static void SplitFullName(string input)
{
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Lỗi: Chuỗi không được trống!");
        return;
    }

    string trimmed = input.Trim();
    string[] words = trimmed.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    if (words == null)
    {
        Console.WriteLine("Lỗi: Mảng kết quả null!");
        return;
    }

    Console.WriteLine("Các từ:");
    for (int i = 0; i < words.Length; i++)
    {
        Console.WriteLine(words[i]);
    }
}

static string FindLongestWord(string input)
{
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Lỗi: Chuỗi không được trống!");
        return "";
    }

    string trimmed = input.Trim();
    string[] words = trimmed.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    string longest = "";
    for (int i = 0; i < words.Length; i++)
    {
        if (words[i].Length > longest.Length)
        {
            longest = words[i];
        }
    }
    return longest;
}

static int CountNonNullStrings(string[] arr)
{
    if (arr == null)
    {
        return 0;
    }

    int count = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (!string.IsNullOrWhiteSpace(arr[i]))
        {
            count++;
        }
    }
    return count;
}
