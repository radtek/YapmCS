using System.Collections.Generic;
using System;

public abstract class cGeneralObject
{

    // Number of actions executed
    private static int _actionCount = 1;

    // Is it a new item ?
    private bool _newItem = false;

    // Item is killed ?
    private bool _killedItem = false;

    // Item is displayed ?
    private bool _isDisplayed = false;

    // Creation date of an item
    internal DateTime _objectCreationDate;

    // Contains list of all pending tasks
    internal static Dictionary<int, System.Threading.WaitCallback> _SharedPendingTasks = new Dictionary<int, System.Threading.WaitCallback>();
    // Contains list of current pending tasks of the object
    internal Dictionary<int, System.Threading.WaitCallback> _pendingTasks = new Dictionary<int, System.Threading.WaitCallback>();

    // Semaphore to protect dico of pendingTasks
    public static System.Threading.Semaphore globalSemPendingtask = new System.Threading.Semaphore(1, 1);

    // Type of item
    // This kind of stuff break the inheritance... but who cares ??
    internal Native.Api.Enums.GeneralObjectType _TypeOfObject;


    public cGeneralObject()
    {
        _objectCreationDate = DateTime.Now;
    }

    public static int GetActionCount()
    {
        // This could be considered as a atomic operation...
        _actionCount += 1;
        return _actionCount;
    }

    // Add a pending task to the list
    // "Shared" is called in shared methods
    public void AddPendingTask(int actionCount, ref System.Threading.WaitCallback thr)
    {
        globalSemPendingtask.WaitOne();
        _SharedPendingTasks.Add(actionCount, thr);
        _pendingTasks.Add(actionCount, thr);
        globalSemPendingtask.Release();
    }
    public static void AddSharedPendingTask(int actionCount, ref System.Threading.WaitCallback thr)
    {
        globalSemPendingtask.WaitOne();
        _SharedPendingTasks.Add(actionCount, thr);
        globalSemPendingtask.Release();
    }

    // Remove a pending task from the list
    // "Shared" is called in shared methods
    public void RemovePendingTask(int actionCount)
    {
        globalSemPendingtask.WaitOne();
        if (_SharedPendingTasks.ContainsKey(actionCount))
            _SharedPendingTasks.Remove(actionCount);
        if (_pendingTasks.ContainsKey(actionCount))
            _pendingTasks.Remove(actionCount);
        globalSemPendingtask.Release();
    }
    public static void RemoveSharedPendingTask(int actionCount)
    {
        globalSemPendingtask.WaitOne();
        if (_SharedPendingTasks.ContainsKey(actionCount))
            _SharedPendingTasks.Remove(actionCount);
        globalSemPendingtask.Release();
    }

    // Return pending tasks
    public Dictionary<int, System.Threading.WaitCallback> GetPendingTasks
    {
        get
        {
            return _pendingTasks;
        }
    }
    public static Dictionary<int, System.Threading.WaitCallback> GetAllPendingTasks
    {
        get
        {
            return _SharedPendingTasks;
        }
    }

    // Return count of pending task
    public int PendingTaskCount
    {
        get
        {
            globalSemPendingtask.WaitOne();
            int _cout = 0;
            foreach (System.Threading.WaitCallback th in _pendingTasks.Values)
            {
                if (th != null)
                    _cout += 1;
            }
            globalSemPendingtask.Release();
            return _cout;
        }
    }
    public int AllPendingTaskCount
    {
        get
        {
            globalSemPendingtask.WaitOne();
            int _cout = 0;
            foreach (System.Threading.WaitCallback th in _SharedPendingTasks.Values)
            {
                if (th != null)
                    _cout += 1;
            }
            globalSemPendingtask.Release();
            return _cout;
        }
    }

    // Is item displayed, killed or new ?
    public bool IsDisplayed
    {
        get
        {
            return _isDisplayed;
        }
        set
        {
            _isDisplayed = value;
        }
    }
    public bool IsKilledItem
    {
        get
        {
            return _killedItem;
        }
        set
        {
            _killedItem = value;
        }
    }
    public bool IsNewItem
    {
        get
        {
            return _newItem;
        }
        set
        {
            _newItem = value;
        }
    }

    // Type of item
    public Native.Api.Enums.GeneralObjectType TypeOfObject
    {
        get
        {
            return _TypeOfObject;
        }
    }


    // Get information by name
    // The first simply retrieve the information, and the second one
    // remember last value retrieved, and return True if it has changed
    public abstract string GetInformation(string info);
    public abstract bool GetInformation(string info, ref string res);

    // List of available properties for the cXXX object
    public abstract string[] GetAvailableProperties(bool includeFirstProp = false, bool sorted = false);

    // Return backcolor of the item, when displayed in a listview
    public virtual System.Drawing.Color GetBackColor()
    {
        return System.Drawing.Color.White;
    }

    // Return forecolor of the item, when displayed in a listview
    public virtual System.Drawing.Color GetForeColor()
    {
        return System.Drawing.Color.Black;
    }
}

