import { useEffect } from "react";
import { View, Text, TouchableOpacity } from "react-native";
import { Feather } from "@expo/vector-icons";
import Animated, {
  BounceIn,
  FadeIn,
  FadeOut,
  useAnimatedStyle,
  useSharedValue,
  withSpring,
} from "react-native-reanimated";

const TouchableOpacityAnimated =
  Animated.createAnimatedComponent(TouchableOpacity);

import { styles } from "./styles";

type Props = {
  value: number;
  onMoveTop: () => void;
};

export function ProgressBar({ value, onMoveTop }: Props) {
  const widthContainer = useSharedValue(200);
  const endReached = value >= 98;
  const animatedStyle = useAnimatedStyle(() => {
    return {
      width: widthContainer.value,
    };
  });

  useEffect(() => {
    widthContainer.value = withSpring(endReached ? 56 : 200, { mass: 0.4 });
  }, [value]);

  return (
    <Animated.View style={[styles.container, animatedStyle]}>
      {endReached ? (
        <TouchableOpacityAnimated
          entering={BounceIn}
          exiting={FadeOut}
          onPress={onMoveTop}
        >
          <Feather name="arrow-up" size={24} color="#c4c4cc" />
        </TouchableOpacityAnimated>
      ) : (
        <Animated.View
          style={styles.progressContent}
          entering={FadeIn}
          exiting={FadeOut}
        >
          <Text style={styles.value}>{value.toFixed(0)}%</Text>

          <View style={styles.tracker}>
            <View style={[styles.progress, { width: `${value}%` }]}></View>
          </View>
        </Animated.View>
      )}
    </Animated.View>
  );
}
