#include "Wrapper.h"

CheckpointTimeLogger timeLogger;

PLUGIN_API void ResetLogger() {
	return timeLogger.ResetLogger();
}

PLUGIN_API void SaveCheckpointTime(float intervals) {
	return timeLogger.SaveCheckpointTime(intervals);
}

float GetTotalTime() {
	return timeLogger.GetTotalTime();
}

float GetCheckpointTime(int index) {
	return timeLogger.GetCheckpointTime(index);
}

int GetNumCheckpoints() {
	return timeLogger.GetNumCheckpoints();
}
