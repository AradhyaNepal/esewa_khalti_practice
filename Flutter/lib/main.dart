import 'package:esewa_khalti/common/utils/dio_and_generic_state_setup.dart';
import 'package:esewa_khalti/features/splash/view/splash_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

void main() {
  dioAndGenericStateSetup();
  runApp(
    ProviderScope(
      parent: MyApp.globalRef,
      child: const MyApp(),
    ),
  );
}

class MyApp extends StatelessWidget {
  static final globalRef=ProviderContainer();
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
        useMaterial3: true,
      ),
      home: const SplashScreen(),
    );
  }
}
