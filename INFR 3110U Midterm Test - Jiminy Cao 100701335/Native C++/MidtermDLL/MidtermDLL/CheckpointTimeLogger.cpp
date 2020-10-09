#include "CheckpointTimeLogger.h"

void CheckpointTimeLogger::ResetLogger() {
    RTBC.clear();

    TotalRunTime = 0.0f;
}

void CheckpointTimeLogger::SaveCheckpointTime(float intervals) {
    RTBC.push_back(intervals);

    TotalRunTime += intervals;
}

float CheckpointTimeLogger::GetTotalTime() {
    return TotalRunTime;
}

float CheckpointTimeLogger::GetCheckpointTime(int index) {
    return RTBC[index];
}

int CheckpointTimeLogger::GetNumCheckpoints() {
    return RTBC.size();
}
