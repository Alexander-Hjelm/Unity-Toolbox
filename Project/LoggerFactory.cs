using UnityEngine;
using System.Collections;

public static class LoggerFactory {

    private static long sessionInstaceId;
    private static string logPath = @"Z:\Projects\Unity Projects\SGame\Log\";

    public static void setSessionInstanceId(long id) {
        sessionInstaceId = id;
    }

    public static Logger getLogger () {
        
        return new Logger(sessionInstaceId, logPath);
	}
}