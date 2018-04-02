using UnityEngine;
using System.Collections;
using System;

public class SessionID : MonoBehaviour {

    //Unique idetifier of this unity game session, for use when e.g. building loggers
    public long sessionInstaceId;

	void Awake () {
        setSessionInstanceId(DateTime.Now.Ticks);
        LoggerFactory.setSessionInstanceId(sessionInstaceId);
	}

    private void setSessionInstanceId(long id) {
        this.sessionInstaceId = id;
    }

    public long getSessionInstanceId() {
        return this.sessionInstaceId;
    }
}