using UnityEngine;

public class FileManagerHandler : MonoBehaviour
{
    public FileManager FileManager { get; private set; }
    private string _generalFilePath = "Список ссылок.txt";
    private string _removedFilePath = "Корзина.txt";
    private string _tagsFilePath = "Список тегов.txt";

    private void Awake()
    {
        _generalFilePath = Application.persistentDataPath + '/' + _generalFilePath;
        _removedFilePath = Application.persistentDataPath + '/' + _removedFilePath;
        _tagsFilePath = Application.persistentDataPath + '/' + _tagsFilePath;
        FileIO fileIO = new FileIO();
        FileManager = new FileManager(fileIO, _generalFilePath, _removedFilePath, _tagsFilePath);
    }
}
