import { useState, useRef } from "react";
import { ScrollView, Text, View, useWindowDimensions } from "react-native";
import { ProgressBar } from "../../components/ProgressBar";
import { styles } from "./styles";

type ScrollProps = {
  layoutMeasurement: {
    height: number;
  };
  contentOffset: {
    y: number;
  };
  contentSize: {
    height: number;
  };
};

export function Post() {
  const [percentage, setPercentage] = useState(0);
  const scrollRef = useRef<ScrollView>(null);
  const dimensions = useWindowDimensions();

  function scrollPercentage({
    contentSize,
    contentOffset,
    layoutMeasurement,
  }: ScrollProps) {
    const visibleContent = Math.ceil(
      (dimensions.height / contentSize.height) * 100
    );

    const value =
      ((layoutMeasurement.height + contentOffset.y) / contentSize.height) * 100;

    setPercentage(value < visibleContent ? 0 : value);
  }

  function handleScrollMoveTop() {
      scrollRef.current?.scrollTo({
        x: 0,
        y: 0,
        animated: true,
      });
  }

  return (
    <View style={styles.container}>
      <ScrollView
        ref={scrollRef}
        showsHorizontalScrollIndicator={false}
        contentContainerStyle={styles.content}
        onScroll={(event) => scrollPercentage(event.nativeEvent)}
      >
        <Text style={styles.title}>Lorem ipsum</Text>

        <View>
          <Text style={styles.text}>
            Lorem ipsum dolor sit amet consectetur, adipisicing elit. Minima
            ipsam rerum tempora? Quae delectus optio ea facilis architecto
            quisquam voluptas, aspernatur, corporis odio vel totam voluptatem!
            Consequatur unde iste incidunt?
          </Text>
          <Text style={styles.text}>
            Lorem ipsum dolor sit amet consectetur, adipisicing elit. Minima
            ipsam rerum tempora? Quae delectus optio ea facilis architecto
            quisquam voluptas, aspernatur, corporis odio vel totam voluptatem!
            Consequatur unde iste incidunt? Lorem ipsum dolor sit amet
            consectetur, adipisicing elit. Minima ipsam rerum tempora? Quae
            delectus optio ea facilis architecto quisquam voluptas, aspernatur,
            corporis odio vel totam voluptatem! Consequatur unde iste incidunt?
          </Text>

          <Text style={styles.text}>
            Lorem ipsum dolor sit amet consectetur, adipisicing elit. Minima
            ipsam rerum tempora? Quae delectus optio ea facilis architecto
            quisquam voluptas, aspernatur, corporis odio vel totam voluptatem!
            Consequatur unde iste incidunt? Lorem ipsum dolor sit amet
            consectetur, adipisicing elit. Minima ipsam rerum tempora? Quae
            delectus optio ea facilis architecto quisquam voluptas, aspernatur,
            corporis odio vel totam voluptatem! Consequatur unde iste incidunt?
            Lorem ipsum dolor sit amet consectetur, adipisicing elit. Minima
            ipsam rerum tempora? Quae delectus optio ea facilis architecto
            quisquam voluptas, aspernatur, corporis odio vel totam voluptatem!
            Consequatur unde iste incidunt? Lorem ipsum dolor sit amet
            consectetur, adipisicing elit. Minima ipsam rerum tempora? Quae
            delectus optio ea facilis architecto quisquam voluptas, aspernatur,
            corporis odio vel totam voluptatem! Consequatur unde iste incidunt?
            Lorem ipsum dolor sit amet consectetur, adipisicing elit. Minima
            ipsam rerum tempora? Quae delectus optio ea facilis architecto
            quisquam voluptas, aspernatur, corporis odio vel totam voluptatem!
            Consequatur unde iste incidunt? Lorem ipsum dolor sit amet
            consectetur, adipisicing elit. Minima ipsam rerum tempora? Quae
            delectus optio ea facilis architecto quisquam voluptas, aspernatur,
            corporis odio vel totam voluptatem! Consequatur unde iste incidunt?
            Lorem ipsum dolor sit amet consectetur, adipisicing elit. Minima
            ipsam rerum tempora? Quae delectus optio ea facilis architecto
            quisquam voluptas, aspernatur, corporis odio vel totam voluptatem!
            Consequatur unde iste incidunt? Lorem ipsum dolor sit amet
            consectetur, adipisicing elit. Minima ipsam rerum tempora? Quae
            delectus optio ea facilis architecto quisquam voluptas, aspernatur,
            corporis odio vel totam voluptatem! Consequatur unde iste incidunt?
          </Text>
        </View>
      </ScrollView>
      <ProgressBar value={percentage} onMoveTop={handleScrollMoveTop} />
    </View>
  );
}
