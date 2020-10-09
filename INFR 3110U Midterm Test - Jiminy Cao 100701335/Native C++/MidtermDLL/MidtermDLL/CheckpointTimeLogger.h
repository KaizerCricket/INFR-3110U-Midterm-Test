#pragma once
#include "PluginSettings.h"
#include <vector>

class PLUGIN_API CheckpointTimeLogger {
public:
	void ResetLogger();

	void SaveCheckpointTime(float intervals);

	float GetTotalTime();

	float GetCheckpointTime(int index);

	int GetNumCheckpoints();

private:
	float TotalRunTime = 0.0f;
	std::vector<float> RTBC;
};

