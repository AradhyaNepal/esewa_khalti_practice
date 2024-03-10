
import 'package:esewa_khalti/features/payment/controller/payment_repo_controller.dart';
import 'package:esewa_khalti/main.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:generic_state_bya2/generic.dart';
final paymentProvider=StateNotifierProvider<PaymentNotifier,GenericState<String>>((ref) => PaymentNotifier(InitialState()));
class PaymentNotifier extends StateNotifier<GenericState<String>> {
  PaymentNotifier(super.state);

  void getPaymentDetails() async {
    try {
      state = LoadingState();
      final details =
          await MyApp.globalRef.read(paymentRepoProvider).getPaymentDetails();
      state=SuccessState(details);
    } catch (e, s) {
      state = ErrorState(e, s);
    }
  }
}

